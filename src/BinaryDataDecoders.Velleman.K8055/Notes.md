# Velleman K8055

## Summary

This library allows for interfacing with the Velleman K8055 directly without the native library from Velleman

## Notes

https://github.com/rm-hull/k8055/blob/598b236d807aa060f9d9ee774fa2c202c99ed3cb/README.md
http://libk8055.sourceforge.net/

\\?\hid#vid_10cf&pid_5503#7&2ebcec2&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}

03 00 00 00 00 00 08 01  => reset counter 1 (10ms, 0ms)
04 00 00 00 00 00 08 01  => reset counter 2 (10ms, 0ms)
05 01 00 00 00 00 08 01  => digital out 1 (10ms, 0ms)
05 03 00 00 00 00 08 01  => digital out 1+2 (10ms, 0ms)
05 ff 00 00 00 00 08 01  => digital out all (10ms, 0ms)
05 ff ff ff 00 00 08 01  => digital out all + analog1,2 (10ms, 0ms)
05 ff ff 00 00 00 08 01  => digital out all + analog1 = 255,2=0 (10ms, 0ms)
05 ff ff 00 00 00 01 01  => digital out all + analog1 = 255,2=0 (0ms, 0ms)
05 ff ff 00 00 00 58 58  => digital out all + analog1 = 255,2=0 (1000ms, 1000ms)
06 00 00 00 00 00 08 01  => ? read ?