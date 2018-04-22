# CarPerformanceTracker

A .NET standard library to connect to OBD2 compatible onboard diagnostics.

## Example Usage

1. Create a class that implements `IObd2Connection`.
2. Create an instance of `IObd2Connection` and pass it to the constructor of `Obd2Interface`.

## Sources
- https://en.wikipedia.org/wiki/OBD-II_PIDs

## Connecting on iOS

1. Once connected to that Wi-Fi network, click the small blue arrow to go to the advanced settings for it. 
2. Set the IP Address to Static. 
3. Configure the IP address to 192.168.0.123 and the Subnet Mask to 255.255.255.0. 
4. In your App, configure the connection to use a custom TCP connection with IP 192.168.0.10 and TCP Port 35000.

