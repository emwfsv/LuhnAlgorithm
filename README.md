# LuhnAlgorithm
## Simple Luhn Algorithm library together with Console App & Unit tests

## LuhnAlgorithm
The project contains of a library file with simple functions to do calculations according to Luhn Algorithm.

Following functions Exists:
- CheckPersonalIdNumber => Check if an entered Swedish "Personnummer" if it´s valid.
- CheckOcr => Check Swedish OCR number if it´s correct.
- CheckIccId => Mobile ICCID number check.

### Implementations:
---
CheckPersonalIdNumber
---
<pre><code>var la = new LuhnAlgorithm();
var result = la.CheckPersonalIdNumber("640823-3234");</code></pre>
---
CheckOcr
---
<pre><code>var la = new LuhnAlgorithm();
var result = la.CheckOcr("8946071612600065785670");</code></pre>
---
CheckIccId
---
<pre><code>var la = new LuhnAlgorithm();
var result = la.CheckIccId("4015115100");</code></pre>

## LuhnTestApp
Simple console application that will let you test swedish "Personnummer".

## TestOfLuhnCalculation
Unit test for functions found in LuhnAlgorith library file.
