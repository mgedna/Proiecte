package ebiblioteca;

import java.awt.*;
import java.awt.event.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.TimeUnit;
import javax.swing.*;

public class InterfataImprumut1 extends JFrame
{
    JLabel lNume, lCNP, lCarti, lReturnare, lImprumutare;
    JTextField tNume, tCNP, tReturnare, tImprumutare;
    JTextArea taCarti;
    JButton bImprumuta, bInapoi;
    JComboBox comboCarti;
    String[] listaCarti;
    JPanel p1, p2, p3, p4, p5;
    
    InterfataImprumut1()
    {
        super("Imprumut");
        AscultatorInterfata1 ai = new AscultatorInterfata1();
        lNume = new JLabel("Nume si prenume");
        lNume.setFont(new Font("Book Antiqua", Font.PLAIN, 15));

        
        lCNP = new JLabel("Carte identitate: CNP");
        lCNP.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lCarti = new JLabel("Alege carti");
        lCarti.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lImprumutare = new JLabel("Data imprumutare");
        lImprumutare.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lReturnare = new JLabel("Data returnare");
        lReturnare.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tNume = new JTextField(15);
        tNume.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        tCNP = new JTextField(15);
        tCNP.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        taCarti = new JTextArea();
        taCarti.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        taCarti.setEditable(false);
        taCarti.setBackground(new Color(253,245,230));
        tImprumutare = new JTextField(15);
        tImprumutare.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        tReturnare = new JTextField(15);
        tReturnare.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        comboCarti = new JComboBox();
        comboCarti.setFont(new Font("Book Antiqua", Font.PLAIN, 13));
        listaCarti = Carte.coduri();
        
        for(int i=0;i<listaCarti.length;i++)
            comboCarti.addItem(listaCarti[i]);
        
        AscultatorCombo ac = new AscultatorCombo();
        comboCarti.addActionListener(ac);
        
        p1 = new JPanel();
        p1.setLayout(new GridLayout(2,2));
        p1.add(lNume); p1.add(tNume);
        p1.add(lCNP); p1.add(tCNP);
        p1.setBackground(new Color(253,245,230));
        
        p2 = new JPanel();
        GridLayout l = new GridLayout(1,3);
        l.setHgap(10);
        p2.setLayout(l);
        p2.add(lCarti); p2.add(comboCarti); p2.add(taCarti);
        p2.setBackground(new Color(253,245,230));
        
        p3 = new JPanel();
        p3.setLayout(new GridLayout(2,2));
        p3.add(lImprumutare); p3.add(tImprumutare);
        p3.add(lReturnare); p3.add(tReturnare);
        p3.setBackground(new Color(253,245,230));
        
        p4 = new JPanel();
        bImprumuta = new JButton("Imprumuta");
        bImprumuta.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bImprumuta.setBackground(new Color(255,228,196));
        bImprumuta.addActionListener(ai);
        bInapoi = new JButton("Inapoi");
        bInapoi.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bInapoi.setBackground(new Color(255,228,196));
        bInapoi.addActionListener(ai);
        p4.add(bInapoi);
        p4.add(bImprumuta);
        p4.setBackground(new Color(253,245,230));
      
        p5 = new JPanel();
        p5.setLayout(new GridLayout(2,1));
        p5.add(p2);
        p5.add(p3);
        p5.setBackground(new Color(253,245,230));

        getContentPane().add(p1,BorderLayout.NORTH);
        getContentPane().add(p5);
        getContentPane().add(p4, BorderLayout.SOUTH);

        pack();
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
    }
    
    class AscultatorInterfata1 implements ActionListener
    {   
        private Carte c;
        private JFrame f;
        Imprumut i;
        
        public void actionPerformed(ActionEvent e)
        {
            if (e.getSource()==bImprumuta)
            {
                if(tNume.getText().equals("")==false && tCNP.getText().equals("")==false && tImprumutare.getText().equals("")==false && tReturnare.getText().equals("")==false )
                {   
                    Persoana p=new Persoana();
                    if(p.verifica_cnp(tCNP.getText())==true)
                    {   p.setNume(tNume.getText());
                        p.setCod(tCNP.getText());
                        //p = new Persoana(tNume.getText(), tCNP.getText());
                        String cod = (String)comboCarti.getSelectedItem();
                        c=Carte.cautaCarte(cod);
                        String di = tImprumutare.getText();
                        String dr = tReturnare.getText();
                        
                        try{
                            SimpleDateFormat format=new SimpleDateFormat("dd/MM/yyyy");
                            format.setLenient(false); //pentru ca textul sa fie analizat trebuie sa fie in formatul specificat, adica nu va accepta 29/02/2022 de exemplu
                            Date d1=format.parse(di);
                            Date d2=format.parse(dr);
                            if(d2.before(d1)==false)
                            {
                                long diferenta_milisec = Math.abs(d2.getTime()-d1.getTime());
                                long diferenta = TimeUnit.DAYS.convert(diferenta_milisec,TimeUnit.MILLISECONDS);
                                if(diferenta<=14)
                                {
                                    i = new Imprumut(p,c,di,dr);
                                    c.setStare(true);
                                    Carte.salveaza();
                                    JOptionPane.showMessageDialog(null,"Imprumutul a fost realizat cu succes!", "Imprumut realizat", JOptionPane.INFORMATION_MESSAGE);
                                    dispose();
                                }
                                else
                                    JOptionPane.showMessageDialog(null,"Nu se poate realiza imprumutul pe o perioada mai mare de 14 zile!", "Eroare", JOptionPane.ERROR_MESSAGE);
                            }
                            else
                                JOptionPane.showMessageDialog(null,"Nu se poate realiza imprumutul: verificati campurile Data imprumut si Data returnare!", "Eroare", JOptionPane.ERROR_MESSAGE);
                        }
                        catch(ParseException pex)
                        {
                            JOptionPane.showMessageDialog(null,"Format incorect! Incercati tipul 'dd/MM/yyyy'!", "Eroare", JOptionPane.ERROR_MESSAGE);
                        }
                    }
                else
                    JOptionPane.showMessageDialog(null,"Nu se poate realiza imprumutul: CNP invalid!", "Eroare", JOptionPane.ERROR_MESSAGE);   
            }
            else 
                JOptionPane.showMessageDialog(null,"Nu se poate realiza imprumutul: exista campuri necompletate!", "Eroare", JOptionPane.ERROR_MESSAGE);
            }
            
            else
                if (e.getSource()==bInapoi)
                    dispose();
        }
    }
    
    class AscultatorCombo implements ActionListener
    {
        public void actionPerformed(ActionEvent e)
        {
            JComboBox cb=(JComboBox)e.getSource();
            String selectat=(String)cb.getSelectedItem();
            taCarti.setText(Carte.cautaCarte(selectat).infoCarte());
        }
    }
}