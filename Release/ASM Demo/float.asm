.def
@include "stringtools.asm"
.data

@label data_begin
var T1 (122)/2
var T2 255+25
var data_len $ - data_begin + 1

.code
@entry

ld r0, T1
putf r0

putcd endl

ld r0, T2
puti r0

putcd endl

ld r0, data_len 
puti r0

putcd endl

mov r1, 2.0 + 0.71281828459045
ln r1
putf r1

halt
