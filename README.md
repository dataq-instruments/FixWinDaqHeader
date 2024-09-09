# Utility for Fixing Common Issues with WinDaq Headers 

If your hard drive is damaged or power is lost during data acquisition, your WinDaq file may become corrupted. This can lead to errors such as: "Illegal header value 8 bytes from the start of the file.", "Illegal header value 12 bytes from the start of the file", "Illegal header value 16 bytes from the start of the file", "Illegal header value 28 bytes from the start of the file." or "Illegal header value 44 bytes from the start of the file".

This ChatGPT generated simple utility is designed to address such issues. It examines damaged WinDaq files, adjusts the file size, forcely removes event markers and annotations, and make sure compression and sample interval are both positive numbers, and saves a repaired version that you can open.

How to Use

Copy the corrupted WinDaq file to the same folder where fix_windaq.exe is located. We will use a corrupted Windaq file Sample.Wdq for example below

Run the utility using the following command: 

fix_windaq.exe SAMPLE.WDQ

This will generate a repaired version named SAMPLE_modified.WDQ. You can try the other corrupted Windaq files in the same GitHub folder

Warning: The utility forcely removes event markers and user annotations

Customization and Further Repairs

You can modify the program to include additional tests and remedial actions for repairing more complex issues with your WinDaq file.

For more info regarding WinDaq header, please visit https://www.dataq.com/resources/techinfo/ff.htm

Other errors concerning illegal value in header higher than offset 110, such as "Illegal header value 118 bytes from the start of the file", usually indicates a more complicated problem. This blog https://www.dataq.com/blog/analysis-software/reset-the-windaq-header-to-clear-up-illegal-header-value-errors/ shows how to repair it.
