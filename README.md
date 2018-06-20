# .NetCoreGpioLibrary for Raspberry Pi

This is a small Library to simplify the work with GPIOs on the Raspberry Pi in your .NetCore application.

## Prerequisites

You should already have a working .NetCore environment on your Raspberry set up.

## Installation

1. [Download](http://www.dropwizard.io/1.0.2/docs/) the dll file
2. Add the library to your existing Projekt


## Use the library

### Setup GPIO ports

Before using a GPIO port you have to configure it:

```c#
Gpio.SetUpPort(Port.PORT10, Direction.OUT);  // Write to port
Gpio.SetUpPort(Port.PORD27, Direction.IN);   // Read from port
```

If your input signal is inverted you can simply invert that:

```c#
Gpio.SetUpPort(Port.PORD27, Direction.IN, true);   // Read from inverted port
```

### Write/Read from GPIOs

To write a signal to a port:
```c#
Gpio.SetPortState(Port.PORT10, State.HIGH);  
```

To read a signal on a port:
```c#
Gpio.GetPortState(Port.PORT27);  
```

### Example

```c#
Gpio.SetUpPort(Port.PORT10, Directon.OUT);

while(true)
{
    Gpio.SetPortState(Port.PORT10, State.HIGH);
    Thread.Sleep(250);
    Gpio.SetPortState(Port.PORT10, State.LOW);
    Thread.Sleep(250);
}
```