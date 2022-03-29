package lab7;

import java.awt.Color;
import java.awt.EventQueue;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import java.awt.Font;
import javax.swing.JTextField;
import javax.swing.JSpinner;
import javax.swing.SpinnerNumberModel;
import javax.swing.table.DefaultTableModel;
import javax.swing.JCheckBox;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JTable;
import javax.swing.JPanel;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class ex3 {

	private JFrame frame;
	private JTextField txtFilm;
	private JLabel lblFilm;
	private JLabel lblActori;
	private JTextField txtActori;
	private JSpinner spinner;
	private JLabel lblAnLansare; 
	private JCheckBox check_comedy;
	private JCheckBox check_drama;
	private JCheckBox check_historyic;
	private JCheckBox check_romantic;
	private JCheckBox check_action;
	private JButton btnAdauga;
	private JButton btnSterge;
	private JScrollPane scrollPane;
	private DefaultTableModel new_TabelModel;
	private String[] table_array;
	private JPanel panel;
	private JTable table;
	private boolean check_1 = false;
	private boolean check_2 = false;
	private boolean check_3 = false;
	private boolean check_4 = false;
	private boolean check_5 = false;

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ex3 window = new ex3();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	
	
	public ex3() {
		initialize();
	}

	private void initialize() {
		frame = new JFrame("Filme");
		frame.setBounds(100, 100, 684, 440);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		new_TabelModel = new DefaultTableModel(0,0);
		table_array = new String [] {"Film","Actori","An lansare","Genuri"};
		new_TabelModel.setColumnIdentifiers(table_array);
		
		lblFilm = new JLabel("Film");
		lblFilm.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblFilm.setBounds(173, 31, 39, 21);
		frame.getContentPane().add(lblFilm);
		
		lblActori = new JLabel("Actori\r\n");
		lblActori.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblActori.setBounds(173, 63, 65, 21);
		frame.getContentPane().add(lblActori);
		
		txtFilm = new JTextField();
		txtFilm.setBounds(218, 33, 282, 21);
		frame.getContentPane().add(txtFilm);
		txtFilm.setColumns(10);
		
		txtActori = new JTextField();
		txtActori.setColumns(10);
		txtActori.setBounds(218, 65, 282, 21);
		frame.getContentPane().add(txtActori);
		
	    spinner = new JSpinner();
		spinner.setModel(new SpinnerNumberModel(2021, 2015, 2021, 1));
		spinner.setBounds(228, 92, 58, 27);
		frame.getContentPane().add(spinner);
		
		lblAnLansare = new JLabel("An lansare");
		lblAnLansare.setBounds(173, 95, 78, 21);
		frame.getContentPane().add(lblAnLansare);
		
		check_comedy = new JCheckBox("comedie");
		check_comedy.setFont(new Font("Tahoma", Font.PLAIN, 12));
		check_comedy.setBounds(195, 143, 75, 21);
		frame.getContentPane().add(check_comedy);
		check_comedy.setFocusable(false);
		
		check_drama = new JCheckBox("drama");
		check_drama.setFont(new Font("Tahoma", Font.PLAIN, 12));
		check_drama.setBounds(272, 143, 65, 21);
		frame.getContentPane().add(check_drama);
		check_drama.setFocusable(false);
		
		check_historyic = new JCheckBox("istoric");
		check_historyic.setFont(new Font("Tahoma", Font.PLAIN, 12));
		check_historyic.setBounds(337, 143, 58, 21);
		frame.getContentPane().add(check_historyic);
		check_historyic.setFocusable(false);
		
		check_romantic = new JCheckBox("romantic");
		check_romantic.setFont(new Font("Tahoma", Font.PLAIN, 12));
		check_romantic.setBounds(397, 143, 78, 21);
		frame.getContentPane().add(check_romantic);
		check_romantic.setFocusable(false);
		
		check_action = new JCheckBox("actiune");
		check_action.setFont(new Font("Tahoma", Font.PLAIN, 12));
		check_action.setBounds(295, 175, 65, 21);
		frame.getContentPane().add(check_action);
		check_action.setFocusable(false);
		
		
		btnAdauga = new JButton("Adauga");
		btnAdauga.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				boolean not_first = false;
				String string_film = txtFilm.getText();
				if(string_film.equals("") || string_film.equals(" ")) {
					string_film = "Eroare";
				}
				String string_actors = txtActori.getText();
				if(string_actors.equals("") || string_actors.equals(" ")) {
					string_actors = "Eroare";
				}
				int int_year = (int) spinner.getValue();
				String string_year = String.valueOf(int_year);
				String string_genres = "";
				String new_string = ",";
				
				if(check_comedy.isSelected() == true) {
					if(not_first == false) {
						string_genres += check_comedy.getText();
						check_1 = true;
						not_first = true;
					} else if(not_first == true) {
						string_genres += new_string + check_comedy.getText();
						check_1 = true;
						not_first = true;
					}
				} if(check_drama.isSelected() == true) {
					if(not_first == false) {
						string_genres += check_drama.getText();
						check_2 = true;
						not_first = true;
					} else if(not_first == true) {
						string_genres += new_string + check_drama.getText();
						check_1 = true;
						not_first = true;
					}
				} if(check_historyic.isSelected() == true) {
					if(not_first == false) {
						string_genres += check_historyic.getText();
						check_3 = true;
						not_first = true;
					} else if(not_first == true) {
						string_genres += new_string + check_historyic.getText();
						check_1 = true;
						not_first = true;
					}
				} if(check_romantic.isSelected() == true) {
					if(not_first == false) {
						string_genres += check_romantic.getText();
						check_4 = true;
						not_first = true;
					} else if(not_first == true) {
						string_genres += new_string + check_romantic.getText();
						check_4 = true;
						not_first = true;
					}
				} if(check_action.isSelected() == true) {
					if(not_first == false) {
						string_genres += check_action.getText();
						check_5 = true;
						not_first = true;
					} else if(not_first == true) {
						string_genres += new_string + check_action.getText();
						check_4 = true;
						not_first = true; 
					}
				}
				if(check_1 == false && check_2 == false && check_3 == false && check_4 == false && check_5 == false) {
					string_genres = "Eroare";
				}
				
				
				new_TabelModel.addRow(new Object[] { string_film, string_actors, string_year, string_genres});
			}
		});
		btnAdauga.setBounds(195, 216, 91, 32);
		frame.getContentPane().add(btnAdauga);
		btnAdauga.setFocusable(false);
		
		btnSterge = new JButton("Sterge");
		btnSterge.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int [] new_int_array = table.getSelectedRows();
				int new_len = new_int_array.length;
				for(int i=new_len-1;i>=0;i--) {
					new_TabelModel.removeRow(new_int_array[i]);
				}
			}
		});
		btnSterge.setBounds(382, 216, 91, 32);
		frame.getContentPane().add(btnSterge);
		btnSterge.setFocusable(false);
		new_TabelModel.setColumnIdentifiers(table_array);
		
		panel = new JPanel();
		panel.setBounds(160, 130, 342, 75);
		panel.setBorder(BorderFactory.createTitledBorder("Genuri"));
		frame.getContentPane().add(panel);
		
		scrollPane = new JScrollPane();
		scrollPane.setBounds(38, 259, 595, 121);
		frame.getContentPane().add(scrollPane);
		
		table = new JTable();
		table.setModel(new_TabelModel);
		scrollPane.setViewportView(table);
	}
}

