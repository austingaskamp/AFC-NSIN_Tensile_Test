using System;
using System.Collections.Generic;
using System.IO.Ports; //needs to be referenced by entire package
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCell_OwnProgram
{
    public class ThermoClass
    {
        private string name = "Thermocouple Array";
        private string comPort = "COM9";
        private int buadRate = 115200; //DO NOT CHANGE uncless arduino sketch is changed as well
        private SerialPort serialPort;

        private List<float> tc1Data = new List<float>(); //TC1 data structure
        private List<float> tc2Data = new List<float>(); //TC2 data structure
        private List<float> tc3Data = new List<float>(); //TC3 data structure
        private List<float> tc4Data = new List<float>(); //TC4 data structure

        //Constructor
        public ThermoClass()
        {

            serialPort = new SerialPort("COM9", 115200);
            serialPort.Open(); //Will throw 'System.IO.IOException' if the COM port does not exist
        }
        public ThermoClass(string comPort)//opening com port
        {
            serialPort = new SerialPort(comPort, 115200);
            serialPort.Open(); //Will throw 'System.IO.IOException' if the COM port does not exist
        }

        //Get and set functions for name
        public void setName(string userInputName) { name = userInputName; }
        public string getName() { return name; }

        //Get and set functions for com port
        public void setComPort(string userInputComPort) { comPort = userInputComPort; }
        public string getComPort() { return comPort; }
        public void closeComPort() { serialPort.Close(); }

        //Get and set functions for baud rate
        public void setBaudRate(int userInputBaudRate) { buadRate = userInputBaudRate; }
        public int getBuadRate() { return buadRate; }

        //Returns all temperature readings of TC 1 [should be the PID TC] & adds single temp reading to TC1 data array
        //TC1
        public List<float> getTC1Data()
        {
            if (tc1Data == null)
            {
                return new List<float> { -1 }; 
            }
            return tc1Data;
        }
        public float getCurrentTC1Temp() {
            if (tc1Data == null || tc1Data.Count == 0)
            {
                return float.NaN; 
            }
            return tc1Data[tc1Data.Count - 1]; }
        public void addTemp1(float temp) { tc1Data.Add(temp); }

        //TC2
        public List<float> getTC2Data()
        {
            if (tc2Data == null)
            {
                return new List<float> { -2 }; 
            }
            return tc2Data;
        }
        public float getCurrentTC2Temp()
        {
            if (tc2Data == null || tc2Data.Count == 0)
            {
                return float.NaN; 
            }
            return tc2Data[tc2Data.Count - 1];
        }
        public void addTemp2(float temp) { tc2Data.Add(temp); }

        //TC 3
        public List<float> getTC3Data()
        {
            if (tc1Data == null)
            {
                return new List<float> { -2 };
            }
            return tc1Data;
        }
        public float getCurrentTC3Temp()
        {
            if (tc2Data == null || tc2Data.Count == 0)
            {
                return float.NaN; // return a hyphen (-1) if tc1Data is null or empty
            }
            return tc2Data[tc2Data.Count - 1];
        }
        public void addTemp3(float temp) { tc3Data.Add(temp); }

        //TC 4
        public List<float> getTC4Data() { return tc4Data; }
        public float getCurrentTC4Temp()
        {
            if (tc4Data.Count == 0)
            {
                return float.NaN; // return NaN if tc4Data is empty
            }
            return tc4Data[tc4Data.Count - 1];
        }
        public void addTemp4(float temp) { tc4Data.Add(temp); }

        //Record all 4 temperature readings
        public List<float> recordCurrentTemps()
        {
            //Data array with float variables read in from arduino, getCurrentTemps used to read in from serial port (arduino) and to convert string to float list w/ the 4 temps
            List<float> currentTempList = getCurrentTemps();

            //Add data to TC data structures
            addTemp1(currentTempList[0]);
            addTemp2(currentTempList[1]);
            addTemp3(currentTempList[2]);
            addTemp4(currentTempList[3]);

            return currentTempList;
        }

        //Returns all 4 temperature readings as List
        public List<float> getCurrentTemps()
        {

            if (this.serialPort.BytesToRead > 0)
            {
                string data = serialPort.ReadLine().Trim();
                List<float> currentTemps = new List<float>();

                foreach (string str in data.Split(','))
                {
                    float temp;

                    if (float.TryParse(str, out temp))
                    {
                        currentTemps.Add(temp);
                    }
                }

                if (currentTemps.Count == 4)
                {
                    return currentTemps;
                }

                else
                {
                    System.Console.WriteLine(serialPort.ReadLine().Trim());
                    System.Console.WriteLine("4 temps not returned.");
                    List<float> currentTemps2 = new List<float>() { 99999, 99999, 99999, 99999 };
                    return currentTemps2; // Handle the case where the input string doesn't contain exactly 4 numbers... - need to change to exception throwing
                }

            }

            else
            {
                Console.WriteLine(serialPort.ReadLine().Trim()); //with this line in, you get NaN, error when hitting stop, and no export to .csv
                Console.WriteLine("No data collected from serial port.");
                List<float> currentTemps3 = new List<float>() { 99999, 99999, 99999, 99999 };
                return currentTemps3; //No data collected from serial port - need to change to exception throwing
            }
        }
    
    }
}
