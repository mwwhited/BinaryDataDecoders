# BinaryDataDecoders.ToolKit.Tests.Codecs.MorseCodeTests

## DecodeTest (.- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----,ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
.- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. ----- -> ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890
```

## EncodeTest (abcdefghijklmnopqrstuvwxyz1234567890,.- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
abcdefghijklmnopqrstuvwxyz1234567890 -> .- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----
```

## DecodeTest (.... . .-.. .-.. ---  .-- --- .-. .-.. -..,HELLO WORLD)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
.... . .-.. .-.. ---  .-- --- .-. .-.. -.. -> HELLO WORLD
```

## EncodeTest (Hello, World!,.... . .-.. .-.. ---  .-- --- .-. .-.. -..)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Hello, World! -> .... . .-.. .-.. ---  .-- --- .-. .-.. -..
```

## EncodeTest (hello world,.... . .-.. .-.. ---  .-- --- .-. .-.. -..)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
hello world -> .... . .-.. .-.. ---  .-- --- .-. .-.. -..
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
