https://github.com/mwwhited/EmbeddedBakery/tree/main/circuits/h4n2rs485
https://raw.githubusercontent.com/mwwhited/EmbeddedBakery/main/circuits/h4n2rs485/h4n2rs485.png
http://www.g7smy.co.uk/2017/04/controlling-the-zoom-h2n-audio-recorder-with-arduino/

marcuswolschon.blogspot.com/2012/04/easterhegg-basel-2012.html


For the next 4 days I am on EasterHegg and reverse engeneering the protocol spoken between the RC04 remote and the Zoom H4n audio recorder.
This posting is constantly being updated and rewritten with details as they come up. 
Newsticker:
Friday
So far no luck with the OpenBench logic sniffer. 
Can't figure out if the buffered inputs support 3.3V signals or only 5V signals. We are trying to verify this by connecting and disconnecting the on-board 3.3V supply to an input-pin to get a known signal.
But we are out of chocolate and coffee!!!
Saturday
I fetched my pocket-oscilloscope from home but forgot 2 cables.
Contacted "Nussgipfel" for an oscilloscope because he holds an oscilloscope-workshop tonight. So he must have a working device. Hope to verify that the signal is 3.3V and count it's frequency/bitrate to get the OpenBench to work on decoding it. 
Hacked my pocket-Oscilloscope. Found a 5V signal (-0.5 to 4.5V and -1 to 4V) in the 600-800Hz range. 

Aus 2012-04-07_EasterHegg
Decoded the signal 

Aus 2012-04-07_EasterHegg
Batteries died while decoding the LED signals. Buttons are decoded. 
Sunday
Trying to find Nussgipfel again to make screenshots of the undistorted waveforms and document my findings below. 
Found a second signal being transmitted with >100ms delay after the first signal. Need help analysing it. 

Aus 2012-04-07_EasterHegg
checked the signal using a larger scope. Seems I had GND and Signal confused on the small one. Low<->High. May be RS232 after all? With start+stop -bit the signal checks out. 2.400 = 417 µs per bit seems to match our 0,4ms per bit.
Making a break to eat some fondue down in the huuuuuuge bunker below this building. Planning to use a larger logic analyser later.
...
Monday
...


Aus 2012-01-22_RC04 
Observations: 

The 4 connections between RC04 remote and H4n are labeled 3.3V, RX, TX and GND.

The single chip on the remote is labeled "D78f0500A"
It could be an NEC microcontroller µPD78f0500.
The number of pins and the pins connected to RX, TX and SCK seem to match.
The datasheet is in Korean but what I can make out is that this should be a 5MHz microcontroller that can run on 3.3V and 5V. No details from the datasheet cast and light on the strange encoding used(described below). 

What I found out about the protocol being transmitted by the RC04 remote on the 2 lines "RX" and "TX" when certain buttons are pressed on the remote or the Zoom H4n lights up certain LEDs is as follows:

Findings:


 The protocoll is RS232 at 3.3V with 2400bps 8n1
The remote sends 2 sequences of 2 bytes with a small delay:
Record: 0x81 0x00 | 0x80 0x00
Play:   0x82 0x00 | 0x80 0x00
Stop:   0x84 0x00 | 0x80 0x00
ffwd:   0x88 0x00 | 0x80 0x00
rwd:    0x90 0x00 | 0x80 0x00
vol+:   0x80 0x08 | 0x80 0x00
vol-:   0x80 0x10 | 0x80 0x00
rec+:   0x80 0x20 | 0x80 0x00
rec-:   0x80 0x40 | 0x80 0x00
mic :   0x80 0x01 | 0x80 0x00
ch1 :   0x80 0x02 | 0x80 0x00
ch2 :   0x80 0x04 | 0x80 0x00

It receives a single byte that is a bitmask of the LEDs to light up:



? && 0x01 = record LED
? && 0x10 = MIC LED
? && 0x60 == CH1+CH2 LED = 0x20 + 0x40 
? && 0x20 = CH1 green
? && 0x40 = CH2 green
? && 0x04 = CH1 red 0x16?
? && 0x08 = CH2 red


? && 0x24 = CH1 yellow (red+green)
? && 0x48 = CH2 yellow (red+green)



==================================

http://www.g7smy.co.uk/2017/04/hacking-the-zoom-h2n-remote/

g7smy.co.uk
 
Search
Skip to content

Arduino, Electronics, Hardware, Interesting 
Hacking the Zoom H2n Remote Control
14th April 2017 Karl 
The Zoom H2n is a portable sound recorder looking like an old fashioned microphone it is a handheld device that provides an assortment of stereo and surround recording modes, it records onto an SD card in MP3 or WAV format with options for various bitrates and frequencies. The unit is powered internally by two AA batteries and can also be powered from the USB port. The recorder I am experimenting on has firmware version 2.00 installed.

A not at all contrived image of the Zoom H2n Portable Recorder
The Zoom Remote Controller RC2 is a wired four pin 2.5mm jack plug connection, this remote has three buttons: record, mark, and pause there is also an LED to show when the H2n is recording. It is purchased separately from the recorder and only appears to be available bundled in an accessory pack. It looks difficult to take apart without leaving some damage, and this may not be necessary for decoding.

Zoom Remote and breadboard for testing
In this post I am looking to see how the remote works and find what control method it employs so in Part Two I can use an Arduino style micro-controller to provide an external trigger such as for timed recordings.
Setup for Testing
For testing I have made a breakout lead, this is essentially an extension cable split in half with a couple of molex style connectors allowing me to plug it into a breadboard. With this I have found the cable has the following connections, with pin one being the tip of the 2.5mm jack plug:
Remote Receive – RX
Remote Transmit – TX
Ground
3.1V – Power
When checking with a multimeter I found continuity from the negative of the left battery (on the Mic Gain side) to pin three, ground, of the jack, there is also a connection between the positive of the right-hand battery to pin one of the jack but on the multimeter in diode mode there looks to be a capacitor, the voltage rises until no apparent connection is indicated. With no activity on the recorder the RX and TX pins show ~2.7 volts.
Determining the RX and TX pins turned out to be straightforward. When you press the record button after a moment the recording LED lights up, on the oscilloscope I can see three different square wave patterns for the three different buttons on the TX pin and a single type of square wave on RX to light the LED. The following images show the signal for the record button then that sent in response to to light the LED.

Signal sent by the remote when Record pressed

Signal sent by the Zoom recorder to light the LED in the remote
Also when buttons are pressed on the recorder data is seen on the RX line. For a more detailed examination I will need to break out the logic analyser.
Signal Analysis
Following some research where the remote for a Zoom H4n was examined, I set both channels being used on the logic analyser to the following:
Protocol: UART
2400 baud, 8 bits, no parity, 1 stop (8n1)
Bit Order: LSB first, inverted logic: No

Decoding of the first part of the stop recording command
First I decoded the buttons on the remote with the trigger on the logic analyser set to falling edge on the Remote TX line. On TX there is a pause between the two pairs of command bytes which appears to be the length of time the button was pressed, around 350-500ms, there is also a pause between bytes in the RX response, the value of the response changes depending on which recording mode you are in, those shown below are when the recorder is in XY Stereo:
Record Start
TX:
0x81 0x0
~
0x80 0x0

RX:
0x20
1.85s
0x20 0x21
record LED on
Record Stop
TX:
0x81 0x0
~
0x80 0x0

RX:
0x21 0x21 0x20
1.9s
0x20 0x20
record LED off
Pause (while recording)
TX:
0x80 0x2
~
0x80 0x0

RX:
0x21
51ms
0x21 0x20
then this repeats

492ms
0x20 0x21
to flash the LED

492ms
0x21 0x20
until pause is pressed again
Resume from Pause
TX:
0x80 0x2
~
0x80 0x0

RX:
0x21 0x21

LED on
Mark
TX:
0x80 0x1
~
0x80 0x0

RX:
0x21
492ms
0x20 0x21
LED on
I was also able to capture the following activity sent to the remote when various buttons were pressed on the recorder itself with the recorder in XY Stereo mode. Other models of the recorders made by Zoom have more advanced remotes, such as the RC4 as featured in this hack of the H4n. I suspect they would work on this machine too. This time I set the logic analyser to trigger with a falling edge on Remote RX. I think the 0x20 code is used to indicate the display illumination has been turned off. I saw activity on all buttons except the Mic Gain knob.
Power On – Without remote attached
TX:
Lots of random activity
RX:
0x10
400ms
0x80 0x81


1.2s
0x10 0x0 0x80 0x0


140ms
0x0 0x0 0x80 0x80 0x0 


~2ms
0x0 0x80 0x0 0x0 0x80 0x0 

Power On – With remote attached
TX:
0x0
five pulses 30ms apart

30ms
0x0 0xA1 0x80 0x0 0xA1

RX:
following pulses on TX
0x80 0x81 0x80 0x10


1.2s
0x10 0x0


148ms
0x0 0x0


~4ms
0x0 0x0 0x0

Record Start
RX:
0x20
20ms
0x20 0x21
LED on
Record Stop
RX:
0x21 0x21 0x21 0x20
~
0x20


~283ms
0x20 0x20
 LED off
Menu \ Home – Into Menu
RX:
0x20 0x20 0x0

Exit from Menu
RX:
0x20
45ms
0x20

Play Switch: Up/Down/Press
RX:
0x20
55ms
0x20

Clipping detect (tapping the microphone with a pen)
RX:
0x10 0x2
56ms
0x2


59ms
0x10


60ms
0x10


354ms
0x10

Volume: Up and Down
RX:
0x20

Recording Mode Change: 4 channel surround
RX:
0x10 0x10 0x30
14ms
0x30 0x30


122ms
0x34


60ms
0x30


60ms
0x30

Recording Mode Change: XY Stereo
RX:
0x30 0x30 0x20
216ms
0x20

Recording Mode Change: 2 channel surround
RX:
0x20 0x20 0x30 0x30
18ms
0x30


148ms
0x30


164ms
0x30 0x6


56ms
0x14 0x30


477ms
0x30

Recording Mode Change: MS Stereo
RX:
0x30 0x30 0x10
170ms
0x10


50ms
0x12

I think these response codes are to light up various LED’s on the more advanced Zoom RC4 remote, this suggests that other remotes would work in this recorder.
The following table shows the response codes given with different microphone configurations when record is clicked to start recording:
TX:
0x81 0x0 ~100ms delay 0x80 0x0
XY Stereo:
0x20 750ms delay 0x20 0x21
2 Channel Surround:
0x30 750ms delay 0x30 0x31
MS Stereo:
0x10 750ms delay 0x10 0x11
4 Channel Surround:
0x30 750ms delay 0x30 0x31
In Part Two I will be covering the use of a Arduino style micro-controller as an alternative remote control.
Links and Sources
Manufacturers Page: Zoom H2n
Hacking the Zoom H4n remote
Logic Analyser: https://www.ikalogic.com/scanaplus/
Share this:
Click to share on Twitter (Opens in new window)
Click to share on Facebook (Opens in new window)
Click to share on Google+ (Opens in new window)
Post navigation
Previous Post
Fixing the Arduino incoming network connections error on the mac
Next Post
Controlling the Zoom H2n Audio Recorder with Arduino
COMPUTERS, ROBOTS AND PHOTOGRAPHY
Site Search
Search for:
 
