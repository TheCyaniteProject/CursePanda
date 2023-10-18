# CursePanda
A slow-buring C# upgrade to Firecoder. I'll only be gradually working on it as I have time.

Currently only has basic encoding abilities with little fluff.

```
-f - File input
-o - File output (otherwise will print in the console)
-p - Password to use while encoding
-d - Decoding mode (otherwise defaults to Encoding)

Example>CursePanda.exe -f "input.txt" -o "output.cpe" -p pass1
```

I have tested images, .zip folders, and .exe executables, all were successful.
Encodes at around 100,000 bytes/s on my system (Ryzen 5)

It currently works by converting Unicode into Base64(ASCII) and then uses a character map generated from your password to mix up the characters.
While not impossible to break (since I'm using .NET's build-in RNG method to generate the map from the password hash) it's still pretty good and will be effectivly unbreakable for those without cyber security backgrounds, unless they guess your password :3

Disclaimer: I am not a cyber security expert. I'm just a person who likes computers and dabbles with fun projects like this on occasion. Use at your own risk.

