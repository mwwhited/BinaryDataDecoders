	• Radex One
		○ Examples
			// read data request
			>: 7BFF 2000 0600 1800 ____ 4600 0008 0C00 F3F7
			<: 7AFF 2080 1600 1800 ____ 3680 0008 ____ 0C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7
			
			//read serial number request (SN: 180620-0840-008344 v1.8)
			>: 7BFF 2000 0600 9B0D ____ C2F2 0100 0C00 F2FF
			<: 7AFF 2080 1E00 9B0D ____ AB72 0100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 0612 0108 4803 0800 ____ D61D
			
			//Write request... repeat three times
			>: 7BFF 2000 1000 FA05 ____ 59FA 0208 0E00 0500 ____ 020A ____ ____ E8ED
			<: 7AFF 2080 0600 FA05 ____ 647A 0208 ____ FDF7
			
			//Read settings request
			>: 7BFF 2000 0600 FD05 ____ 60FA 0108 _C00 F2F7
			<: 7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
			§ 
		○ Output
			§ Prefix [0x7b, 0xff]
			§ Request? [0x20, 0x00]
			§ Extension Length? [0xLL, 0xHH]
			§ Packet Number [0xLL, 0XHH]
			§ Zero Reserved [0x00, 0x00]
			§ CheckSum [FFFF - Sum(Prefix…ZeroReserve) % FFFF]
			§ Extensions --- (Number of Bytes referenced by Extension Length)
				□ Request Type 
					® [0x00, 0x08] Request Data Read
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x00] Request Serial Number/Version Read
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x02, 0x08] Request Write Settings 
						◊ 0e00 Reserved? [0x0e, 0x00]
						◊ Target Value [0x05, 0x00]
						◊ Zero Reserved [0x00, 0x00]
						◊ Alarm Setting [0x03] {0x01 = Vibration, 0x02 = 0 Audio}
						◊ Threshold [0xLL, 0xHH]
						◊ Zero Reserved [0x00, 0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x08] Request Read Settings
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
		○ Inbound
			§ Prefix [0x7a, 0x00]
			§ Response? [0x02, 0x80]
			§ Extension Length? [0xLL, 0xHH]
			§ Packet Number [0xLL, 0XHH]
			§ Zero Reserved [0x00, 0x00]
			§ CheckSum [FFFF - Sum(Prefix…ZeroReserve) % FFFF]
			§ Extensions --- (Number of Bytes referenced by Extension Length)
				□ Response Type 
					® [0x00, 0x08] Return Data ReadZero 
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {ambient}
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {accumulated}
						◊ Reserved [0x00, 0x00]
						◊ 0c00 Reserved? [0xLL, 0xHH] {cpm}
						◊ Reserved [0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x00] Return Serial Number/Version Read
						◊ 0c00 Reserved? [0x0c, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x02, 0x08] Acknowledge Write Settings 
						◊ Zero Reserved [0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]
					® [0x01, 0x08] Return Read Settings
						◊ Zero Reserved [0x00, 0x00]
						◊ Target Value [0x05, 0x00]
						◊ Zero Reserved [0x00, 0x00]
						◊ Alarm Setting [0x03] {0x01 = Vibration, 0x02 = 0 Audio}
						◊ Threshold [0xLL, 0xHH]
						◊ Zero Reserved [0x00, 0x00, 0x00]
						◊ CheckSum [FFFF - Sum(Request type…ZeroReserve) % FFFF]


	// read data request
	<: 7AFF 2080 1600 1800 ____ 3680 0008 ____ 0C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7
	
	//read serial number request (SN: 180620-0840-008344 v1.8)
	<: 7AFF 2080 1E00 9B0D ____ AB72 0100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 0612 0108 4803 0800 ____ D61D
		splash	08344-002-06-18; v1.8
		box	83440620 NA
		app	180620-0840-008344; v1.8
		
	//Write request... repeat three times
	<: 7AFF 2080 0600 FA05 ____ 647A 0208 ____ FDF7
	
	//Read settings request
	<: 7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
	
