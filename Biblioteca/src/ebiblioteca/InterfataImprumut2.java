package ebiblioteca;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.*;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.concurrent.TimeUnit;
import javax.swing.*;

public class InterfataImprumut2 extends JFrame
{
    JLabel lNume, lCNP, lCarti, lPlata, lTotal;
    JTextField tNume, tCarti, tPlata, tCNP, tTotal;
    JButton bOk, bUrmator, bAnterior, bPlata;
    JPanel p1, p2, p3;
    private double plata=0;
    
    InterfataImprumut2()
    {
        super("Imprumut");
        AscultatorInterfata2 aii = new AscultatorInterfata2();
        lNume = new JLabel("Nume si prenume");
        lNume.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lCNP = new JLabel("Carte identitate: CNP");
        lCNP.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lCarti = new JLabel("Carti imprumutate: ");
        lCarti.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lPlata = new JLabel("Plata: ");
        lPlata.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        lTotal = new JLabel("Total de plata: ");
        lTotal.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        
        tNume = new JTextField(15);
        tNume.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tNume.setEditable(false);
        tCNP = new JTextField(15);
        tCNP.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tCNP.setEditable(false);
        tCarti = new JTextField(15);
        tCarti.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tCarti.setEditable(false);
        tPlata = new JTextField(15);
        tPlata.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tPlata.setEditable(false);
        tTotal = new JTextField(15);
        tTotal.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tTotal.setEditable(false);
        
        p1 = new JPanel();
        p1.setLayout(new GridLayout(3,2));
        p1.add(lNume); p1.add(tNume);
        p1.add(lCNP); p1.add(tCNP);
        p1.add(lCarti); p1.add(tCarti);
        p1.setBackground(new Color(253,245,230));
        
        p2 = new JPanel();
        GridLayout l = new GridLayout(2,2);
        p2.setLayout(l);
        p2.add(lPlata); p2.add(tPlata);
        p2.add(lTotal); p2.add(tTotal);
        p2.setBackground(new Color(253,245,230));

        p3 = new JPanel();
        bOk = new JButton("OK / Returnare");
        bOk.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bOk.setBackground(new Color(255,228,196));
        bUrmator = new JButton("Imprumutul urmator");
        bUrmator.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bUrmator.setBackground(new Color(255,228,196));
        bAnterior = new JButton("Imprumutul anterior");
        bAnterior.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bAnterior.setBackground(new Color(255,228,196));
        bPlata = new JButton("Plateste");
        bPlata.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bPlata.setBackground(new Color(255,228,196));
        bOk.addActionListener(aii);
        bUrmator.addActionListener(aii);
        bAnterior.addActionListener(aii);
        bPlata.addActionListener(aii);
        p3.add(bAnterior); p3.add(bOk); p3.add(bUrmator); p3.add(bPlata);
        p3.setBackground(new Color(253,245,230));
        
        getContentPane().add(p1,BorderLayout.NORTH);
        getContentPane().add(p2);
        getContentPane().add(p3, BorderLayout.SOUTH);
        pack();
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

    }

    class AscultatorInterfata2 implements ActionListener
    {
        private JFrame f;
        private Carte c;
        
        public void actionPerformed(ActionEvent e)
        { 
            if (e.getSource()==bOk)
            { 
                ArrayList<Imprumut> imp=Imprumut.cautaImprumuturi(tCNP.getText());
                String carte=tCarti.getText();
                for(Imprumut i:imp)
                    if(i.getCarte().getTitlu().equals(carte))
                    {
                        i.stergeImprumut();
                        break;
                    }
                c=Carte.cautaTitlu(carte);
                c.setStare(false);
                Carte.salveaza();
                String[] payment=tPlata.getText().split(" ");
                plata+=Double.parseDouble(payment[0]);
                tTotal.setText(plata+" RON");
                Imprumut.scriereImprumuturi();
                JOptionPane.showMessageDialog(null,"Returnarea a fost finalizata cu succes!", "Returnare realizata", JOptionPane.INFORMATION_MESSAGE);
                bAnterior.doClick();
            }
            else 
                if(e.getSource()==bUrmator)
                {
                    int i;
                    ArrayList<Imprumut> imp=Imprumut.cautaImprumuturi(tCNP.getText());
                    for(i=0;i<imp.size();i++)
                    {
                        if(imp.get(i).getCarte().getTitlu().equals(tCarti.getText()))
                            break;
                    }
                    if(i!=imp.size()-1)
                    {
                        tCarti.setText(imp.get(i+1).getCarte().getTitlu());
                        SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
                        Date data_curenta = new Date();
                        long diferenta_milisec = Math.abs(data_curenta.getTime()-imp.get(i+1).getDataReturnare().getTime());
                        long diferenta = TimeUnit.DAYS.convert(diferenta_milisec,TimeUnit.MILLISECONDS);
                        if(imp.get(i+1).getPlata()<imp.get(i+1).getPlata()+diferenta)
                        tPlata.setText((imp.get(i+1).getPlata()+diferenta)+" RON");
                    }
                    else 
                        JOptionPane.showMessageDialog(null,"Nu mai exista imprumuturi pentru acest CNP!", "Eroare", JOptionPane.ERROR_MESSAGE);
                }
                
            else 
                if(e.getSource()==bAnterior)
                {   
                    int i;
                    ArrayList<Imprumut> imp=Imprumut.cautaImprumuturi(tCNP.getText());
                    for(i=0;i<imp.size();i++)
                    {
                        if(imp.get(i).getCarte().getTitlu().equals(tCarti.getText()))
                            break;
                    }
                    if(i!=0)
                    {
                        tCarti.setText(imp.get(i-1).getCarte().getTitlu());
                        SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
                        Date data_curenta = new Date();
                        long diferenta_milisec = Math.abs(data_curenta.getTime()-imp.get(i-1).getDataReturnare().getTime());
                        long diferenta = TimeUnit.DAYS.convert(diferenta_milisec,TimeUnit.MILLISECONDS);
                        if(imp.get(i-1).getPlata()<imp.get(i-1).getPlata()+diferenta)
                            tPlata.setText((imp.get(i-1).getPlata()+diferenta)+" RON");
                    }
                    else 
                        JOptionPane.showMessageDialog(null,"Nu mai exista imprumuturi pentru acest CNP!", "Eroare", JOptionPane.ERROR_MESSAGE);
                }
            else 
                if(e.getSource()==bPlata)
                    {
                        plata=0;
                        JOptionPane.showMessageDialog(null,"Plata a fost efectuata cu succes!", "Returnare realizata", JOptionPane.INFORMATION_MESSAGE);
                        dispose();
                    }
        }
    }
}