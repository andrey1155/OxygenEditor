.def

@define chr_end 255
@include "stringtools.asm"

.data
var test_str 0xAFFF

.code
@entry

mov r4, test_str
ld r4,r4
mov r1, init_string
jsr r1

mov r4, test_str
ld r4,r4
mov r1, print_string
jsr r1

halt
