.def
@define chr_end 255

.data

.code
@entry

@label loop

putc r1
inc r1

cmp r1, chr_end
brne loop


halt

