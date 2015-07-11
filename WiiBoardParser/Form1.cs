using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WiimoteLib;
using System.IO;

namespace WiiBoardParser
{
    public partial class Form1 : Form
    {
        System.Timers.Timer infoUpdateTimer = new System.Timers.Timer() { Interval = 50, Enabled = false };
        //System.Timers.Timer joyResetTimer = new System.Timers.Timer() { Interval = 240000, Enabled = false };

        Wiimote wiiDevice = new Wiimote();
        //string path = @"D:\Projects\WiiBoardParser\WiiBoardParser"; //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = @"D:\Projects\HackCU\HackCU\Assets\Wii Fit\WiiWeight.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Setup a timer which controls the rate at which updates are processed.

            infoUpdateTimer.Elapsed += new ElapsedEventHandler(infoUpdateTimer_Elapsed);
            
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.WriteLine("Hi");
            }
            
                
            


            // Setup a timer which prevents a VJoy popup message.

            // joyResetTimer.Elapsed += new ElapsedEventHandler(joyResetTimer_Elapsed);
        }

        public bool DoesExist()
        {
            return File.Exists(path) ? true : false;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                // Find all connected Wii devices.

                var deviceCollection = new WiimoteCollection();
                deviceCollection.FindAllWiimotes();

                for (int i = 0; i < deviceCollection.Count; i++)
                {
                    wiiDevice = deviceCollection[i];

                    // Device type can only be found after connection, so prompt for multiple devices.

                    if (deviceCollection.Count > 1)
                    {
                        var devicePathId = new Regex("e_pid&.*?&(.*?)&").Match(wiiDevice.HIDDevicePath).Groups[1].Value.ToUpper();

                        var response = MessageBox.Show("Connect to HID " + devicePathId + " device " + (i + 1) + " of " + deviceCollection.Count + " ?", "Multiple Wii Devices Found", MessageBoxButtons.YesNoCancel);
                        if (response == DialogResult.Cancel) return;
                        if (response == DialogResult.No) continue;
                    }

                    // Setup update handlers.

                    wiiDevice.WiimoteChanged += wiiDevice_WiimoteChanged;
                    wiiDevice.WiimoteExtensionChanged += wiiDevice_WiimoteExtensionChanged;

                    // Connect and send a request to verify it worked.

                    wiiDevice.Connect();
                    wiiDevice.SetReportType(InputReport.IRAccel, false); // FALSE = DEVICE ONLY SENDS UPDATES WHEN VALUES CHANGE!
                    wiiDevice.SetLEDs(true, false, false, false);

                    // Enable processing of updates.

                    infoUpdateTimer.Enabled = true;

                    // Prevent connect being pressed more than once.

                    button_Connect.Enabled = false;
                    //button_BluetoothAddDevice.Enabled = false;
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wiiDevice_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            // Called every time there is a sensor update, values available using e.WiimoteState.
            // Use this for tracking and filtering rapid accelerometer and gyroscope sensor data.
            // The balance board values are basic, so can be accessed directly only when needed.
        }

        private void wiiDevice_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs e)
        {
            // This is not needed for balance boards.
        }

        void infoUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Pass event onto the form GUI thread.

            this.BeginInvoke(new Action(() => InfoUpdate()));
        }

        private void InfoUpdate()
        {
            if (wiiDevice.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
            {
                //label_Status.Text = "DEVICE IS NOT A BALANCE BOARD...";
                return;
            }

            // Get the current raw sensor KG values.

            var rwWeight = wiiDevice.WiimoteState.BalanceBoardState.WeightKg;

            var rwTopLeft = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.TopLeft;
            var rwTopRight = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.TopRight;
            var rwBottomLeft = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.BottomLeft;
            var rwBottomRight = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesKg.BottomRight;

            // The alternative .SensorValuesRaw is not adjusted with 17KG and 34KG calibration data, but does that make for better or worse control?
            //
            //var rwTopLeft     = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesRaw.TopLeft     - wiiDevice.WiimoteState.BalanceBoardState.CalibrationInfo.Kg0.TopLeft;
            //var rwTopRight    = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesRaw.TopRight    - wiiDevice.WiimoteState.BalanceBoardState.CalibrationInfo.Kg0.TopRight;
            //var rwBottomLeft  = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesRaw.BottomLeft  - wiiDevice.WiimoteState.BalanceBoardState.CalibrationInfo.Kg0.BottomLeft;
            //var rwBottomRight = wiiDevice.WiimoteState.BalanceBoardState.SensorValuesRaw.BottomRight - wiiDevice.WiimoteState.BalanceBoardState.CalibrationInfo.Kg0.BottomRight;

            // Show the raw sensor values.

            label_rwWT.Text = rwWeight.ToString("0.0");
            label_rwTL.Text = rwTopLeft.ToString("0.0");
            label_rwTR.Text = rwTopRight.ToString("0.0");
            label_rwBL.Text = rwBottomLeft.ToString("0.0");
            label_rwBR.Text = rwBottomRight.ToString("0.0");

            try
            {
                using (StreamWriter wr = new StreamWriter(path))
                {


                    wr.WriteLine("TL = " + label_rwTL.Text);
                    wr.WriteLine("TR = " + label_rwTR.Text);
                    wr.WriteLine("BL = " + label_rwBL.Text);
                    wr.WriteLine("BR = " + label_rwBR.Text);

                }
            }
            catch (IOException e)
            {
                
            }


            // Update joystick emulator.

            //if (checkBox_EnableJoystick.Checked)
            //{
            //    // Uses Int16 ( -32767 to +32767 ) where 0 is the center. Multiplied by 2 because realistic usage is between the 30-70% ratio.

            //    var joyX = (brX * 655.34 + -32767.0) * 2.0;
            //    var joyY = (brY * 655.34 + -32767.0) * 2.0;

            //    // Limit values to Int16, you cannot just (cast) or Convert.ToIn16() as the value '+ - sign' may invert.

            //    if (joyX < short.MinValue) joyX = short.MinValue;
            //    if (joyY < short.MinValue) joyY = short.MinValue;

            //    if (joyX > short.MaxValue) joyX = short.MaxValue;
            //    if (joyY > short.MaxValue) joyY = short.MaxValue;

            //    // Set new values.

            //    joyDevice.SetXAxis(0, (short)joyX);
            //    joyDevice.SetYAxis(0, (short)joyY);
            //    joyDevice.Update(0);
            //}
        }
    }
}
