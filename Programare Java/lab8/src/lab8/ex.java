package lab8;

import java.awt.Color;
import java.awt.Component;
import java.awt.EventQueue;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.JToolBar;
import javax.swing.Timer;

public class ex implements ActionListener {
	private static int count = 0;
	
	private JFrame frame;
	private JToolBar new_tool_bar;
	private JTextField text_field_display;
	private static final int frame_x = 300;
	private static final int frame_y = 300;
	
	private static final int frame_x_pos = 515;
	private static final int frame_y_pos = 500;
	
	
	private JPanel brand_new_panel;
	private JPanel left_panel;
	private JPanel right_panel;
	
	private String url;
	private Statement sql;
	private ResultSet rs;
	private Connection con;
	
	JButton [] new_button_array; 
	
	private static int first_position = 0;
	private static int last_position = 0;
	
	private JLabel label_id;
	private JLabel label_name;
	private JLabel label_age;
	
	private JTextField text_field_id;
	private JTextField text_field_name;
	private JTextField text_field_age;
	
	private int cursor_row = 0;
	private Timer timer;
	
	private static int STATE = 0;
	
	private ActionListener listener;
	private static int once = 0;
	
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ex window = new ex();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
	
	
	protected class SLEEP {
		int mili_to_sleep = 0;
		SLEEP(int mili_to_sleep) {
			this.mili_to_sleep = mili_to_sleep;
		}
		
		public void method_sleep() {
			try {
				Thread.sleep(mili_to_sleep);
			} catch (Exception new_exception) {
				JOptionPane.showMessageDialog(null, "Error 404 caused by exception" +new_exception+ ".", "ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
	}

	public ex() throws SQLException {
		initialize();
	}

	private void initialize() throws SQLException {
		SLEEP obj_decor_sleep = new SLEEP(500);
		obj_decor_sleep.method_sleep();
		frame = new JFrame("Tabel MySQL");
		url = "jdbc:mysql://localhost:3306/lab8";
		con = DriverManager.getConnection (url, "root", "root");
		sql = (Statement) con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
		rs = sql.executeQuery("select * from person_tabel");
		frame.setBounds(frame_x, frame_y, frame_x_pos, frame_y_pos);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		new_tool_bar = new JToolBar();
		new_tool_bar.setLocation(0, 0);
		new_tool_bar.setSize(500,(frame_x+200)/16); 
		frame.getContentPane().add(new_tool_bar);
		int number_of_images = 10;
		text_field_display = new JTextField();
		text_field_display.setEditable(false);
		
	    new_button_array = new JButton[number_of_images];
		for(int i=0;i<number_of_images;++i) {
			new_button_array[i] = new JButton();
			continue;
		}
		
		for(int i=0;i<number_of_images;++i) {
			if(i == 7 || i == 8 || i == 9) {
				new_button_array[i].setFocusable(false);
				new_button_array[i].setIcon(new ImageIcon("src/lab8/" +i+ ".JPG"));
			} else {
				new_button_array[i].setFocusable(false);
				new_button_array[i].setIcon(new ImageIcon("src/lab8/"+ i+ ".png"));
			}
			continue;
		}
		
		//default
			if(rs.first() == true) {
				if(rs.last() == true) {
					for(int i=0;i<number_of_images;++i) {
						if(i == 0 || i == 1 || i == 8 || i == 9) {
							new_button_array[i].setEnabled(false);
						}
					}
				}
			} else {
				for(int i=2;i<number_of_images-2;++i) {
					new_button_array[i].setEnabled(true);
				}
			}
		
		
		for(int i=0;i<number_of_images;++i) {
			if(i == 2) {
				rs.first();
				first_position = rs.getRow();
				rs.last();
				last_position = rs.getRow();
				text_field_display.setText(first_position +" / "+ last_position);
				new_tool_bar.add(text_field_display);
				text_field_display.setColumns(10);
				new_tool_bar.add(new_button_array[i]);
			} else {
				new_tool_bar.add(new_button_array[i]);
			}
			continue;
		}
		
		brand_new_panel = new JPanel();
	
		int panel_x_coord = ((frame_x/2)+150);
		int panel_y_coord = ((frame_y/2)+50);
		
		brand_new_panel.setSize(panel_x_coord, panel_y_coord);
		brand_new_panel.setLocation((frame_x/2)-52, (frame_y/2)-90);
		brand_new_panel.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));
		//brand_new_panel.setBackground(Color.lightGray);
		frame.getContentPane().add(brand_new_panel);
		
		left_panel = new JPanel();
		brand_new_panel.add(left_panel);
		left_panel.setLayout(new BoxLayout(left_panel, BoxLayout.Y_AXIS));
		
		label_id = new JLabel("Id  ");
		left_panel.add(Box.createVerticalStrut(7));
		label_id.setAlignmentX(Component.RIGHT_ALIGNMENT);
		left_panel.add(label_id);
		
		label_name = new JLabel("Name  ");
		left_panel.add(Box.createVerticalStrut(12));
		label_name.setAlignmentX(Component.RIGHT_ALIGNMENT);
		left_panel.add(label_name);
		
		label_age = new JLabel("Age  ");
		left_panel.add(Box.createVerticalStrut(13));
		label_age.setAlignmentX(Component.RIGHT_ALIGNMENT);
		left_panel.add(label_age);
		
		right_panel = new JPanel();
		brand_new_panel.add(right_panel);
		right_panel.setLayout(new BoxLayout(right_panel, BoxLayout.Y_AXIS));
		
		
		text_field_id = new JTextField();
		rs.first(); //pozitionare pe tabela 1
		int int_id = rs.getInt("Id");
		right_panel.add(Box.createVerticalStrut(10));
		String string_id = String.valueOf(int_id);
		text_field_id.setText(string_id);
		text_field_id.setEditable(false);
		right_panel.add(text_field_id);
		text_field_id.setColumns(20);
		

		text_field_name = new JTextField();
		right_panel.add(Box.createVerticalStrut(9));
		String string_name = rs.getString("Name");
		text_field_name.setText(string_name);
		text_field_name.setEditable(false);
		right_panel.add(text_field_name);
		text_field_name.setColumns(10);
		

		text_field_age = new JTextField();
		int int_age = rs.getInt("Age");
		right_panel.add(Box.createVerticalStrut(9));
		String string_age = String.valueOf(int_age);
		text_field_age.setText(string_age);
		text_field_age.setEditable(false);
		right_panel.add(text_field_age);
		text_field_age.setColumns(20);
		
		for(int iterator=0;iterator<new_button_array.length;++iterator) {
			new_button_array[iterator].addActionListener(this);
		}
		
		for(int iterator=0;iterator<new_button_array.length;++iterator) {
			new_button_array[iterator].setActionCommand(String.valueOf(iterator));
		}
		
		if(count == 2) {
			con.close();
			sql.close();
			rs.close();
		}
		count += 1;
		
	}
	
	public void actionPerformed(ActionEvent event) {
		if(event.getActionCommand().equals("0")) {
			try {
				if(rs.first()) { //daca cursorul este la primul row
					cursor_row = rs.getRow();
					text_field_display.setText(cursor_row +" / "+ last_position);
					
					if(rs.isFirst()) {
						once += 1;
						new_button_array[0].setEnabled(false);
						new_button_array[1].setEnabled(false);
					}
					if(!rs.isLast()) {
						once += 1;
						new_button_array[2].setEnabled(true);
						new_button_array[3].setEnabled(true);
					}
					
					int int_id = rs.getInt("Id");
					String string_id = String.valueOf(int_id);
					text_field_id.setText(string_id);

					String string_name = rs.getString("Name");
					text_field_name.setText(string_name);

					int int_age = rs.getInt("Age");
					String string_age = String.valueOf(int_age);
					text_field_age.setText(string_age);
				}
				else {
					rs.next();
				}
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Problems with SQL caused by exzception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
		if(event.getActionCommand().equals("1")) {
			try {
				if(rs.previous()) {
					cursor_row = rs.getRow();
					text_field_display.setText(cursor_row +" / "+ last_position);

					if(rs.isFirst()) {
						once += 1;
						new_button_array[0].setEnabled(false);
						new_button_array[1].setEnabled(false);
					}
					if(!rs.isLast()) {
						once += 1;
						new_button_array[2].setEnabled(true);
						new_button_array[3].setEnabled(true);
					}
					
					int int_id = rs.getInt("Id");
					String string_id = String.valueOf(int_id);
					text_field_id.setText(string_id);

					String string_name = rs.getString("Name");
					text_field_name.setText(string_name);

					int int_age = rs.getInt("Age");
					String string_age = String.valueOf(int_age);
					text_field_age.setText(string_age);
				}
				else {
					rs.next();
				}
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
		if(event.getActionCommand().equals("2")) {
			try {
				if(rs.next()) {
					cursor_row = rs.getRow();
					text_field_display.setText(cursor_row +" / "+ last_position);

					if(rs.isLast()) {
						once += 1;
						new_button_array[2].setEnabled(false);
						new_button_array[3].setEnabled(false);
					}
					if(!rs.isFirst()) {
						once += 1;
						new_button_array[0].setEnabled(true);
						new_button_array[1].setEnabled(true);
					}

					int int_id = rs.getInt("Id");
					String string_id = String.valueOf(int_id);
					text_field_id.setText(string_id);

					String string_name = rs.getString("Name");
					text_field_name.setText(string_name);

					int int_age = rs.getInt("Age");
					String string_age = String.valueOf(int_age);
					text_field_age.setText(string_age);
				}
				else {
					rs.previous();
				}
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
		if(event.getActionCommand().equals("3")) {
			try {
				if(rs.last()) {
					cursor_row = rs.getRow();
					text_field_display.setText(cursor_row +" / "+ last_position);

					if(rs.isLast()) {
						new_button_array[2].setEnabled(false);
						new_button_array[3].setEnabled(false);
					}
					if(!rs.isFirst()) {
						new_button_array[0].setEnabled(true);
						new_button_array[1].setEnabled(true);
					}

					int int_id = rs.getInt("Id");
					String string_id = String.valueOf(int_id);
					text_field_id.setText(string_id);

					String string_name = rs.getString("Name");
					text_field_name.setText(string_name);

					int int_age = rs.getInt("Age");
					String string_age = String.valueOf(int_age);
					text_field_age.setText(string_age);
				}
				else {
					rs.previous();
				}
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Problems with SQL caused by exzception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
		if(event.getActionCommand().equals("4")) {
			STATE = 1;
			for(int i=0;i<new_button_array.length;++i) {
				if(i == 8 || i == 9) {
					new_button_array[i].setEnabled(true);
				} else {
					new_button_array[i].setEnabled(false);
				}
			}
			
			text_field_id.setText("");
			text_field_name.setText("");
			text_field_age.setText("");
			
			text_field_id.setEditable(true);
			text_field_name.setEditable(true);
			text_field_age.setEditable(true);
			
		}
		if(event.getActionCommand().equals("5")) {
			STATE = 2;
			for(int i=0;i<new_button_array.length;++i) {
				if(i == 8 || i == 9) {
					new_button_array[i].setEnabled(true);
				} else {
				new_button_array[i].setEnabled(false);
				}
			}
			
			text_field_id.setText("");
			text_field_name.setText("");
			text_field_age.setText("");
			
			text_field_id.setEditable(true);
			text_field_name.setEditable(true);
			text_field_age.setEditable(true);
		}
		if(event.getActionCommand().equals("6")) {
			int choose = JOptionPane.showConfirmDialog(null,"You are sure that you want to delete the current person?","Confirm deletation",JOptionPane.OK_CANCEL_OPTION,JOptionPane.QUESTION_MESSAGE);
			
			if(choose == JOptionPane.CANCEL_OPTION) {
				JOptionPane.showMessageDialog(null, "No deletation took place", "Back", JOptionPane.ERROR_MESSAGE);
				return;
			} else if(choose == JOptionPane.OK_OPTION) {
				try {
					rs.deleteRow();
					
					last_position -= 1;

					if(last_position == 0) {
						cursor_row = last_position;
						rs.absolute(cursor_row);
						text_field_display.setText(cursor_row +" / "+ last_position);

						text_field_id.setText("");
						text_field_name.setText("");
						text_field_age.setText("");
						
						for(int i=0;i<(new_button_array.length-2);++i) {
							new_button_array[i].setEnabled(false);
						}
						
					  } else {
							if(last_position == 1) {
								cursor_row = last_position;
								rs.absolute(cursor_row);
								text_field_display.setText(cursor_row +" / "+ last_position);

								int int_id = rs.getInt("Id");
								String string_id = String.valueOf(int_id);
								
								String string_name = rs.getString("Name");
								
								int int_age = rs.getInt("Age");
								String string_age = String.valueOf(int_age);
								
								text_field_id.setText(string_id);
								text_field_name.setText(string_name);
								text_field_age.setText(string_age);

								for(int i=0;i<(new_button_array.length-2);++i) {
									int middle = ((new_button_array.length-2)/2);
									int len = (new_button_array.length-2);
									if(i < middle) {
										new_button_array[i].setEnabled(false);
									} else if(len >= middle) {
										new_button_array[i].setEnabled(true);
									}
								}
							} else {
								if(cursor_row == 1) {
									rs.absolute(cursor_row);
									text_field_display.setText(cursor_row +" / "+ last_position);

									int int_id = rs.getInt("Id");
									String string_id = String.valueOf(int_id);
									
									String string_name = rs.getString("Name");
									
									int int_age = rs.getInt("Age");
									String string_age = String.valueOf(int_age);
									
									text_field_id.setText(string_id);
									text_field_name.setText(string_name);
									text_field_age.setText(string_age);
									
									for(int i=0;i<(new_button_array.length-2);++i) {
										if(i == 0 || i == 1) {
											new_button_array[i].setEnabled(false);
										} else {
											new_button_array[i].setEnabled(true);
										}
									}
								} else {
									if(cursor_row > last_position) {
										cursor_row = last_position;
										rs.absolute(cursor_row);
										text_field_display.setText(cursor_row +" / "+ last_position);

										int int_id = rs.getInt("Id");
										String string_id = String.valueOf(int_id);
										
										String string_name = rs.getString("Name");
										
										int int_age = rs.getInt("Age");
										String string_age = String.valueOf(int_age);
										
										text_field_id.setText(string_id);
										text_field_name.setText(string_name);
										text_field_age.setText(string_age);

										for(int i=0;i<(new_button_array.length-2);++i) {
											if(i == 2 || i == 3) {
												new_button_array[i].setEnabled(false);
											} else {
												new_button_array[i].setEnabled(true);
											}
										}
									} else {
										cursor_row -= 1;
										rs.absolute(cursor_row);
										text_field_display.setText(cursor_row +" / "+ last_position);

										int int_id = rs.getInt("Id");
										String string_id = String.valueOf(int_id);
										
										String string_name = rs.getString("Name");
										
										int int_age = rs.getInt("Age");
										String string_age = String.valueOf(int_age);
										
										text_field_id.setText(string_id);
										text_field_name.setText(string_name);
										text_field_age.setText(string_age);

										for(int i=0;i<(new_button_array.length-2);++i) {
											new_button_array[i].setEnabled(true);
										}
									}
								}
							}
					  }
				   } catch (SQLException new_exception) {
					    JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
					 	frame.dispose();
				}
				
			}

		}
		if(event.getActionCommand().equals("7")) {
			String string_name = JOptionPane.showInputDialog("Name you want to find? ");
			try {
				rs.first();
				rs.previous();
				cursor_row = 0;
				while(rs.next()) {
					if(string_name.equals(rs.getString("Name"))) {
						cursor_row = rs.getRow();
						break;
					} 
					continue;
				}
				
				//case 0 - daca nu a fost found inregistrarea ne ducem la inceput iar
				if(cursor_row == 0) {
					once = 0;
					rs.absolute(cursor_row+1);
					text_field_display.setText("error / error");
					listener = new ActionListener() {
						public void actionPerformed(ActionEvent event){
							if(once == 0) {
								text_field_display.setText(cursor_row+1 +" / "+ last_position);
							 }
							once += 1;
							timer.stop();
						}
					};
					
					for(int i=0;i<4;++i) {
						if(i == 0 || i== 1) {
							new_button_array[i].setEnabled(false);
						} else {
							new_button_array[i].setEnabled(true);
						}
					}
				}
				
				
				//daca inregistrarea a fost found
				if(cursor_row >= 1) {
					rs.absolute(cursor_row);
					text_field_display.setText(cursor_row +" / "+ last_position);
				}
				
				int int_id = rs.getInt("Id");
				String string_id = String.valueOf(int_id);
				text_field_id.setText(string_id);

				String string_Name = rs.getString("Name");
				text_field_name.setText(string_Name);

				int int_age = rs.getInt("Age");
				String string_age = String.valueOf(int_age);
				text_field_age.setText(string_age);
				
				
				
				//case 1 - daca avem doar 1 intregistrare
				if(cursor_row == last_position && cursor_row == 1) {
					for(int i=0;i<4;++i) {
						new_button_array[i].setEnabled(false);
					}
				}
				//case 2 - daca avem mai multe inregistrari in database
				else {
					//case 3 - daca suntem la prima stanga dar mai avem inregistrari
					if(cursor_row != last_position && cursor_row == 1) {
						for(int i=0;i<4;++i) {
							if(i == 0 || i == 1) {
								new_button_array[i].setEnabled(false);
							} else {
								new_button_array[i].setEnabled(true);
							}
						}
					} 
					//case 4 - daca suntem la last inregistration si mai avem in stanga
					else if(cursor_row == last_position && cursor_row > 1) {
						for(int i=0;i<4;++i) {
							if(i == 0 || i == 1) {
								new_button_array[i].setEnabled(true);
							} else {
								new_button_array[i].setEnabled(false);
							}
						}
					//case 5 - daca nu ii nici la inceput inregistrationul nici la sfarsit
					} else if(cursor_row != last_position && cursor_row > 1) {
						for(int i=0;i<4;++i) {
							new_button_array[i].setEnabled(true);
						}
					}
				}
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Name "+string_name+ " does not exist in the database!","ERROR 404", JOptionPane.ERROR_MESSAGE);
				return;
			}
		}
		if(event.getActionCommand().equals("8")) {
			if(STATE == 1) {
				try {
					rs.moveToInsertRow();
					
					String string_id = text_field_id.getText();
					int int_id = Integer.parseInt(string_id);
					
					String string_name = text_field_name.getText();
					
					String string_age = text_field_age.getText();
					int int_age = Integer.parseInt(string_age);
					
					rs.updateInt("Id", int_id);
					rs.updateString("Name", string_name);
					rs.updateInt("Age", int_age);
					rs.insertRow();
					
					last_position += 1;

					if(last_position == 1) {
						cursor_row = last_position;
						rs.absolute(last_position);
						text_field_display.setText(last_position +" / "+ last_position);
						
						text_field_id.setText(string_id);
						text_field_name.setText(string_name);
						text_field_age.setText(string_age);
						
						for(int i=0;i<(new_button_array.length-2);++i) {
							int middle = ((new_button_array.length-2)/2);
							int len = (new_button_array.length-2);
							if(i < middle) {
								new_button_array[i].setEnabled(false);
							} else if(len >= middle) {
								new_button_array[i].setEnabled(true);
							}
						}
					} else 
						if(cursor_row == 1) {
							rs.absolute(last_position);
							text_field_display.setText(last_position +" / "+ last_position);

							text_field_id.setText(string_id);
							text_field_name.setText(string_name);
							text_field_age.setText(string_age);

							for(int i=0;i<new_button_array.length-2;++i) {
								if(i == 2 || i == 3) {
									new_button_array[i].setEnabled(false);
								} else {
									new_button_array[i].setEnabled(true);
								}
							}
						} else {
							rs.absolute(last_position);
							text_field_display.setText(last_position +" / "+ last_position);

							text_field_id.setText(string_id);
							text_field_name.setText(string_name);
							text_field_age.setText(string_age);

							for(int i=0;i<new_button_array.length-2;++i) {
								if(i == 2 || i == 3) {
									new_button_array[i].setEnabled(false);
								} else {
									new_button_array[i].setEnabled(true);
								}
							}
					}
					new_button_array[8].setEnabled(false);
					new_button_array[9].setEnabled(false);
							
					text_field_id.setEditable(false);
					text_field_name.setEditable(false);
					text_field_age.setEditable(false);
				} catch (SQLException new_exception) {
					JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
					return;
				}
			}
			
			else if(STATE == 2) {
				try {
					String string_id = text_field_id.getText();
					int int_id = Integer.parseInt(string_id);
					
					String string_name = text_field_name.getText();
					
					String string_age = text_field_age.getText();
					int int_age = Integer.parseInt(string_age);
					
					rs.updateInt("Id", int_id);
					rs.updateString("Name", string_name);
					rs.updateInt("Age", int_age);
					rs.updateRow();
					
					text_field_id.setText(string_id);
					text_field_name.setText(string_name);
					text_field_age.setText(string_age);
					
					if(rs.getRow() == 1 && !rs.isLast()) {
						for(int i=0;i<new_button_array.length-2;++i) {
							if(i == 0 || i == 1) {
								new_button_array[i].setEnabled(false);
							} else {
								new_button_array[i].setEnabled(true);
							}
						}
					} else {
						if(rs.getRow() == last_position && !rs.isFirst()) {
							for(int i=0;i<new_button_array.length-2;++i) {
								if(i == 2 || i == 3) {
									new_button_array[i].setEnabled(false);
								} else {
									new_button_array[i].setEnabled(true);
								}
							}
						} else {
							if(rs.isFirst() && rs.isLast()) {
								for(int i=0;i<(new_button_array.length-2);++i) {
									int middle = ((new_button_array.length-2)/2);
									int len = (new_button_array.length-2);
									if(i < middle) {
										new_button_array[i].setEnabled(false);
									} else if(len >= middle) {
										new_button_array[i].setEnabled(true);
									}
								}
							}
							else {
								for(int i=0;i<new_button_array.length-2;++i) {
									new_button_array[i].setEnabled(true);
								}
							}
						}
					}
					new_button_array[8].setEnabled(false);
					new_button_array[9].setEnabled(false);
							
					text_field_id.setEditable(false);
					text_field_name.setEditable(false);
					text_field_age.setEditable(false);
				} catch (SQLException new_exception) {
					JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
					return;
				}
			}
		}	
		if(event.getActionCommand().equals("9")) {
			try {
				int int_id = rs.getInt("Id");
				String string_id = String.valueOf(int_id);
				
				String string_name = rs.getString("Name");
				
				int int_age = rs.getInt("Age");
				String string_age = String.valueOf(int_age);
				
				text_field_id.setText(string_id);
				text_field_name.setText(string_name);
				text_field_age.setText(string_age);
				
			} catch (SQLException new_exception) {
				JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
				return;
			}
				
				if(last_position == 0) {
					for(int i=0;i<(new_button_array.length-2);++i) {
						if( i== 4) {
							new_button_array[i].setEnabled(true);
						}
						new_button_array[i].setEnabled(false);
					}
				} else {
					if(last_position == 1) {
						for(int i=0;i<(new_button_array.length-2);++i) {
							int middle = ((new_button_array.length-2)/2);
							int len = (new_button_array.length-2);
							if(i < middle) {
								new_button_array[i].setEnabled(false);
							} else if(len >= middle) {
								new_button_array[i].setEnabled(true);
							}
						}
					} else {
						try {
							if(rs.getRow() == 1 && !rs.isLast()) {
								for(int i=0;i<(new_button_array.length-2);++i) {
									if(i == 0 || i == 1) {
										new_button_array[i].setEnabled(false);
									} else {
										new_button_array[i].setEnabled(true);
										}
									}
								} else {
									if(rs.getRow() == last_position && !rs.isFirst()) {
										for(int i=0;i<(new_button_array.length-2);++i) {
											if(i == 2 || i == 3) {
												new_button_array[i].setEnabled(false);
											} else {
												new_button_array[i].setEnabled(true);
											}
										}
									} else {
										for(int i=0;i<(new_button_array.length-2);++i) {
											new_button_array[i].setEnabled(true);
										}
									}
								}
							}catch (SQLException new_exception) {
								JOptionPane.showMessageDialog(null, "Problems with SQL caused by exception " +new_exception,"ERROR 404", JOptionPane.ERROR_MESSAGE);
								return;
						} 
					}
				}
			 new_button_array[8].setEnabled(false);
			 new_button_array[9].setEnabled(false);
						
			 text_field_id.setEditable(false);
			 text_field_name.setEditable(false);
			 text_field_age.setEditable(false);
		  }
		timer = new Timer(1500, listener);
	    timer.setRepeats(false);
	    timer.start();
	}
}
