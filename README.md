# QRDecoder

It is a Desktop Application QrDecoder used to decode any QRCode with a beautiful User Interface while scanning.

<b><h3>Usage</h3></b>
1. Add reference to your Desktop Application Project.
2. Choose QRDecoder.dll.
3. Create a button for scanning QRCode.
4. Add this namespace to the top <i>using QRDecoder;</i>
5. Create a TextBox or Label or anything that will hold the decoded value of QRCode.
6. Add this code:

<code> var scanner = new QRScanner(); </code>

<code> scanner.ShowQRScanner(); </code>

<code> TextBox1.Text = scanner.DecodedQrCode; </code>

<i>Note: TextBox1 is where the value of Decoded QrCode will be putted.</i>

## Video Tutorial
[QR Decoder Video Tutorial](https://www.facebook.com/groups/ProgrammersCodepostingPH/permalink/2063839870344907/)
