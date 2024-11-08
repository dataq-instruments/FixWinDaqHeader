# Utility for Fixing Common Issues with WinDaq Headers 

If your hard drive is damaged or power is lost during data acquisition, your WinDaq file may become corrupted. This can lead to errors such as: "Illegal header value 8 bytes from the start of the file.", "Illegal header value 12 bytes from the start of the file", "Illegal header value 16 bytes from the start of the file", "Illegal header value 28 bytes from the start of the file." or "Illegal header value 44 bytes from the start of the file".

This ChatGPT generated simple utility is designed to address such issues. It examines damaged WinDaq files, adjusts the file size, forcely removes event markers and annotations, and make sure compression and sample interval are both positive numbers, and saves a repaired version that you can open.

How to Use

1) Download fix_windaq.exe and save it to a folder on your hard drive, say c:\test

2) Copy the corrupted WinDaq file to the same folder where fix_windaq.exe is located. We will use a corrupted Windaq file Sample.Wdq for example below

3) Run the utility using the following command from within the directory c:\test: 

    fix_windaq.exe SAMPLE.WDQ

4) This will generate a repaired file named SAMPLE_modified.WDQ in the same file folder c:\test. You can try the other corrupted Windaq files in the same GitHub folder

    Warning: The utility forcely removes event markers and user annotations

Customization and Further Repairs

You can modify the program to include additional tests and remedial actions for repairing more complex issues with your WinDaq file.

For more info regarding WinDaq header, please visit https://www.dataq.com/resources/techinfo/ff.htm

Other errors concerning illegal value in header higher than offset 110, such as "Illegal header value 118 bytes from the start of the file", usually indicates a more complicated problem. This blog https://www.dataq.com/blog/analysis-software/reset-the-windaq-header-to-clear-up-illegal-header-value-errors/ shows how to repair it.

Another error message may occur due to confusion between WDQ and WDH file formats. The error message typically states: 'File... contains 16-bit data, which this application does not support.' WinDaq uses different file formats: files with the .WDQ extension support 14-bit ADC readings, while files with .WDH or .WHC extensions support 16-bit ADC readings. Do not manually change the file extension. To resolve this issue, ensure that the file extension matches the correct ADC reading format used during data collection
