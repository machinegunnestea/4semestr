package com.company;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.util.Random;

public  class Processing{



    public void SecondTask(){
        String text = readFile("resources/text2.txt");
        char[] lowletter = randArr();
        char[] upletter = new char[lowletter.length];
        for (int i =0;i<lowletter.length;i++){
            upletter[i] =Character.toUpperCase(lowletter[i]);
        }
        System.out.println("До шифра\n"+text);
        StringBuffer encText = Enc(new StringBuffer(text),tableChar(lowletter),tableChar(upletter));
        System.out.println("После шифра\n"+encText);
        System.out.println("после дешифра\n"+Dec(encText,tableChar(lowletter),tableChar(upletter)));
    }

    String  readFile(String path){
        try {
            final BufferedReader br = new BufferedReader(new InputStreamReader(new FileInputStream(path),"cp1251"));
            String str = "";
            String temp;
            while ((temp = br.readLine())!=null)str+=temp;
            return str;
        }
        catch (Exception ex){
            System.out.println(ex.getMessage());
            return null;
        }
    }

    static  String delDouble(String text){
        String[] rows = text.split(".  ");
        String result ="";
        int index = 0;

        for (int i = 0; i<rows.length;i++){
            if (rows[i]!=null)
            {
                String[] str = rows[i].split(" ");
                for (int j = 1;j<str.length;j++)
                {
                    if(str[j]!=null&&str[j].equals(str[j-1]))
                    {
                        char[] ch = new char[text.indexOf(str[j-1])-index];
                        text.getChars(index,text.indexOf(str[j-1]),ch,0);
                        result += new String(ch);
                        index = text.indexOf(str[j-1])+str[j-1].length()+1;
                    }
                    if (j==str.length-1)
                    {
                        int len = text.indexOf(str[str.length-1])+str[str.length-1].length();
                        char[] ch = new char[len-index];
                        text.getChars(index,len,ch,0);
                        result+=new String(ch);
                        index=len;
                    }

                }
            }
        }
        return result;
    }

    char[] randArr(){
        char[] letter =new char[]{'a','b','c','d','e','f','g','h','i','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        char[] nl = new char[letter.length];
        boolean inset = true;
        Random random = new Random();
        for (int i = 0;i < letter.length;i++){
            do {
                inset = true;
                int j = random.nextInt(25);
                if (Character.isLetter(nl[j])) inset = false;
                else nl[j] = letter[i];
            }while (!inset);


        }
        return nl;
    }

    char [][] tableChar(char[] ar)
    {
        char[][] table = new char[5][5];
        for (int i = 0, j=0, k=0; i < ar.length && j<5; i++) {
            if(i != 0 && i % 5 == 0) {
                j++;
                k=0;
            }
            table[k][j]=ar[i];
            k++;
        }
        return table;
    }


    char swapEnc(char ch,char[][] t){
        for (int i = 0;i<5;i++){
            for (int j = 0;j<5;j++){
                if(t[i][j] == ch || (t[i][j]== 'i'&& ch == 'j')||(t[i][j]=='I'&& ch=='J'))
                {
                    if (i+1<5)return t[i+1][j];
                    else return t[0][j];
                }
            }
        }
        return ch;
    }

    StringBuffer Enc(StringBuffer ab,char[][] low,char[][] up){
        for (int i = 0;i<ab.length();i++){
            if (Character.isLowerCase(ab.charAt(i))) ab.setCharAt(i,swapEnc(ab.charAt(i),low));
            if (Character.isUpperCase(ab.charAt((i))))ab.setCharAt(i,swapEnc(ab.charAt(i),up));
        }
        return ab;
    }

    char swapDec(char ch,char[][]t){
        for (int i = 0; i <5;i++){
            for (int j = 0;j<5;j++){
                if(t[i][j] == ch || (t[i][j]== 'i'&& ch == 'j')||(t[i][j]=='I'&& ch=='J')){
                    if (i-1>=0)return t[i-1][j];
                    else return t[4][j];
                }
            }
        }
        return ch;
    }

    StringBuffer Dec(StringBuffer sb,char[][]low,char [][] up){
        for (int i = 0;i<sb.length();i++){
            if (Character.isLowerCase(sb.charAt(i))) sb.setCharAt(i,swapDec(sb.charAt(i),low));
            if (Character.isUpperCase(sb.charAt((i)))) sb.setCharAt(i,swapDec(sb.charAt(i),up));
        }
        return sb;

    }
}
