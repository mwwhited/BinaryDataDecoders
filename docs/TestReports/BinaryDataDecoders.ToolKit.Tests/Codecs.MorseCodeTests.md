# BinaryDataDecoders.ToolKit.Tests.Codecs.MorseCodeTests

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

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
