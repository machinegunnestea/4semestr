.model small
.stack 256h

DoNextLine macro
xor dx,dx

lea dx,array
mov ah,09h
int 21h
endm

drawLine macro
mov bx, y
add bx, Ysize
mov y, bx
endm

.data
MsgOutStart db 0Dh, 0Ah,'Input starting x and y:', 0Dh, 0Ah, '$'
MsgOutSize db 'Input flag size:', 0Dh, 0Ah, '$'
MsgOutName db 'Input flag name:', 0Dh, 0Ah, '$'
inputName db 20, 0, 21 dup('$')
array db 0Dh, 0Ah, '$'
standartSize db 10;for normal size
rectangleYsize db 3;size of rectangle
rectangleXsize db 10;size of rectangle
Xlast dw ?
x dw ?
y dw ?
Xsize dw ?;size of picture
Ysize dw ?;size of picture
.code
mov ax, @data
mov ds, ax
mov es, ax

lea dx, MsgOutName ;output msg
mov ah, 09h
int 21h

mov ah,0Ah ;input name
lea dx, inputName
int 21h

mov ah, 09h ;output msg
lea dx, MsgOutStart
int 21h

mov ah, 01h ;input x
int 21h
sub al,30h
mov ah, 0
mov x, ax
DoNextLine

mov ah, 01h ;input y
int 21h
sub al,30h
mov ah,0
mov y, ax
DoNextLine

mov ah, 09h ;output size
lea dx, MsgOutSize
int 21h

mov ah, 01h ;input Xsize
int 21h
sub al,30h
mov ah,0
mov Xsize, ax
DoNextLine

mov ah, 01h ;input Ysize
int 21h
sub al,30h
mov ah,0
mov Ysize, ax
DoNextLine

mov ah, 0 ;graphics mode
mov al, 12h
int 10h

xor bx,bx ;output name Flag
mov bx,x
mov dl,bl

xor bx,bx
mov bx,y
mov dh,bl

xor ax,ax
mov ah,2
xor bx,bx
mov bh,0
int 10h

mov dx,offset inputName + 2
mov ah,9
int 21h

mov ax, x ;multiply to see our flag
mul standartSize
mov x, ax

mov ax,y
mul standartSize
mov y,ax

mov ax,Xsize ;increase size
mul rectangleXsize
mov Xsize,ax

mov ax,Ysize
mul standartSize
mov Ysize,ax

xor ax,ax
xor bx,bx
xor dx,dx
mov cx,x
mov dx,y

;mov bx, Xsize
;add Xlast, bx
;add Xlast, bx
drawLine
go:
mov bx, x
add bx, Xsize
mov Xlast, bx
firstLine:
mov ah, 0Ch
mov al, 2;setting color
mov bh, 0
inc cx
int 10h

cmp cx, Xlast
js firstLine

mov bx, Xsize
add Xlast, bx
secondLine:
mov ah, 0Ch
mov al, 15;setting color
mov bh, 0
inc cx
int 10h

cmp cx, Xlast
js secondLine

mov bx, Xsize
add Xlast, bx
thirdLine:
mov ah, 0Ch
mov al, 4;setting color
mov bh, 0
inc cx
int 10h

cmp cx, Xlast
js thirdLine

inc dx
mov cx, x

cmp dx, y
js go

mov ax,4C00h
int 21h