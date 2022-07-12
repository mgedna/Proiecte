package ebiblioteca;

import java.awt.*;
import java.awt.event.*;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.concurrent.TimeUnit;
import javax.swing.*;

public class InterfataReturnare extends JFrame
{
    JButton bCauta, bInapoi;
    JPanel p1, p2;
    JLabel lCnp;
    JTextField tCnp;
    
    InterfataReturnare()
    {
        super("Returnare");
        AscultatorReturnare ar = new AscultatorReturnare();
        lCnp = new JLabel("CNP");
        tCnp = new JTextField(13);
        lCnp.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        tCnp.setFont(new Font("Book Antiqua", Font.PLAIN, 15));
        bCauta = new JButton("Cauta");
        bCauta.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bCauta.setBackground(new Color(255,228,196));
        bCauta.addActionListener(ar);
        bInapoi = new JButton("Inapoi");
        bInapoi.setFont(new Font("Cascadia Code SemiBold", Font.BOLD, 13));
        bInapoi.setBackground(new Color(255,228,196));
        bInapoi.addActionListener(ar);

        p1 = new JPanel();
        p1.add(lCnp); p1.add(tCnp);
        p1.setBackground(new Color(253,245,230));
        
        p2 = new JPanel();
        p2.add(bInapoi);
        p2.add(bCauta);
        p2.setBackground(new Color(253,245,230));
        
        getContentPane().add(p1, BorderLayout.NORTH);
        getContentPane().add(p2, BorderLayout.SOUTH);
        setPreferredSize(new Dimension(300,100));
        pack();
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
    }
    
    class AscultatorReturnare implements ActionListener
    {
        private JFrame f;
        private Imprumut imp;
        
        public void actionPerformed(ActionEvent e)
        { 
            Persoana p=new Persoana();
            if (e.getSource()==bCauta)
            { 
                String cnp=tCnp.getText();
                if(p.verifica_cnp(cnp)==false)
                    JOptionPane.showMessageDialog(null,"CNP-ul introdus este incorect!", "Eroare", JOptionPane.ERROR_MESSAGE);
                else
                {   
                    ArrayList<Imprumut> i=Imprumut.cautaImprumuturi(cnp);
                    if(i.isEmpty()==false)
                    {
                        imp=i.get(0);
                        InterfataImprumut2 f2 = new InterfataImprumut2();
                        f2.tNume.setText(imp.getPersoana().getNume());
                        f2.tCNP.setText(cnp);
                        f2.tCarti.setText(imp.getCarte().getTitlu());
                        
                        SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
                        Date data_curenta = new Date();
                        
                        long diferenta_milisec = Math.abs(data_curenta.getTime()-imp.getDataReturnare().getTime());
                        long diferenta = TimeUnit.DAYS.convert(diferenta_milisec,TimeUnit.MILLISECONDS);
                        
                        if(imp.getPlata()<imp.getPlata()+diferenta)
                            f2.tPlata.setText((imp.getPlata()+diferenta)+" RON");
                        else
                            f2.tPlata.setText(imp.getPlata()+" RON");
                        f2.pack();
                        f2.setVisible(true);
                        dispose();
                    }
                    else
                        JOptionPane.showMessageDialog(null,"Nu exista niciun imprumut pentru acest CNP!", "Eroare", JOptionPane.ERROR_MESSAGE);                 
                }
            }
            else
                if (e.getSource()==bInapoi)
                    dispose();
        }
    }
}

