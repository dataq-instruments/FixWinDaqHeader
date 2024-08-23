# Utility for Fixing Common Issues with WinDaq Headers 

If your hard drive is damaged or power is lost during data acquisition, your WinDaq file may become corrupted. This can lead to errors such as: "Illegal header value 8 bytes from the start of the file.", "Illegal header value 28 bytes from the start of the file", "Illegal header value 44 bytes from the start of the file", "Illegal header value 12 bytes from the start of the file." or "Illegal header value 16 bytes from the start of the file".

This ChatGPT generated simple utility is designed to address such issues. It examines damaged WinDaq files, adjusts the file size, forcely removes event markers and annotations, and make sure compression and sample interval are both positive numbers, and saves a repaired version that you can open.

How to Use

Copy the corrupted WinDaq file to the same folder where fix_windaq.exe is located.

Run the utility using the following command: 

fix_windaq.exe SAMPLE.WDQ

or

fix_windaq.exe sample_byte28.wdq

or 

fix_windaq.exe sample_byte44.wdq

where SAMPLE.WDQ, sample_byte28.wdq and sample_byte44.wdq are corrupted sample WinDaq files in this folder for testing purpose

This will generate a repaired version named SAMPLE_modified.WDQ or sample_byte28_modified.wdq or sample_byte44_modified.wdq

Warning: The utility forcely removes event markers and user annotations

Customization and Further Repairs

You can modify the program to include additional tests and remedial actions for repairing more complex issues with your WinDaq file.

For more info regarding WinDaq header, please visit https://www.dataq.com/resources/techinfo/ff.htm
