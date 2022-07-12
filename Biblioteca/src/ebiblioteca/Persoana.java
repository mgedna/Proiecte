package ebiblioteca;

import java.util.*;

public class Persoana 
{
    private String nume, CNP;
    public Persoana(){
    }

    public Persoana(String n, String cod)
    {
        nume = n;
        CNP = cod;
    }
    
    public void setNume(String n)
    {
        nume = n;
    }
    
    public void setCod(String cod)
    {
        CNP = cod;
    }
    
    public String getCod()
    {
        return CNP;
    }
    
    public String getNume(){
        return nume;
    }
    
    public boolean verifica_cnp() //verificare CNP instanta astfel incat sa aiba 13 cifre
    {
        char [] ch = CNP.toCharArray();
        if(ch.length == 13)
        {
            for(int i=0; i<ch.length;i++)
                if(Character.isDigit(ch[i]) == false)
                    return false;
        }
        else
            return false;
        return true;
    }
    
    public boolean verifica_cnp(String cnp) //verificarea unui CNP dat ca parametru *metoda supraincarcata*
    {
        char [] ch = cnp.toCharArray();
        if(ch.length == 13)
        {
            for(int i=0; i<ch.length;i++)
                if(Character.isDigit(ch[i]) == false)
                    return false;
        }
        else
            return false;
        return true;
    }
    
    public String toString(){
        return nume+"_"+CNP;
    }
}
