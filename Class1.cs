using System;
using System.Collections.Generic;
using System.IO;

namespace NetCoreGpioLibrary
{
    public class Gpio
    {                  
        private static List<Port> configuredPorts = new List<Port>();

        public static void SetUpPort(Port port, Direction direction, bool invert = false)
        {
            if(!IsPortDirectoryExisting(port))
                CreatePortDirectory(port);
                           
            SetPortDirection(port, direction);

            SetPortInvert(port, invert);

            configuredPorts.Add(port);
        }        

        public static void SetPortState(Port port, State state)
        {
            if(!IsPortConfigured(port))
                throw new Exception(port + " is not set up!");

            if(state == State.HIGH)
                File.WriteAllText("/sys/class/gpio/gpio" + (int)port + "/value", "1");
            else
                File.WriteAllText("/sys/class/gpio/gpio" + (int)port + "/value", "0");
        }

        public static State GetPortState(Port port)
        {
            if(!IsPortConfigured(port))
                throw new Exception("Port: " + (int)port + " is not set up!");

            string value = File.ReadAllText("/sys/class/gpio/gpio" + (int)port +  "/value");
            
            if (value.Contains("1"))
                return State.HIGH;
            else
                return State.LOW;
        }

        private static bool IsPortDirectoryExisting(Port port)
        {
            return Directory.Exists("/sys/class/gpio/gpio" + (int)port);
        }

        private static void CreatePortDirectory(Port port)
        {
            File.WriteAllText("/sys/class/gpio/export", ((int)port).ToString());
        }

        private static void SetPortDirection(Port port, Direction direction)
        {
            File.WriteAllText("/sys/class/gpio/gpio" + (int)port + "/direction", direction.ToString().ToLower());
        }

        private static void SetPortInvert(Port port, bool invert)
        {
            if(invert)
                File.WriteAllText("/sys/class/gpio/gpio" + (int)port + "/active_low", "1");
            else
                File.WriteAllText("/sys/class/gpio/gpio" + (int)port + "/active_low", "0");
        }

        private static bool IsPortConfigured(Port port)
        {
            return configuredPorts.Contains(port);            
        }        
    }

    public enum Direction
    {
        IN,
        OUT
    }

    public enum State
    {
        HIGH,
        LOW
    }

    public enum Port
    {
        PORT2 = 2,
        PORT3 = 3,
        PORT4 = 4,
        PORT17 = 17,
        PORT27 = 27,
        PORT22 = 22,
        PORT10 = 10,
        PORT9 = 9,
        PORT11 = 11,
        PORT5 = 5,
        PORT6 = 6,
        PORT13 = 13,
        PORT19 = 19,
        PORT26 = 26,
        PORT14 = 14,
        PORT15 = 15,
        PORT18 = 18,
        PORT23 = 23,
        PORT24 = 24,
        PORT25 = 25,
        PORT8 = 8,
        PORT7 = 7,
        PORT12 = 12,
        PORT16 = 16,
        PORT20 = 20,
        PORT21 = 21
    }
}
