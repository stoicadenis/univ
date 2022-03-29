package lab9;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTree;
import javax.swing.Timer;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;


public class ex {

	private JFrame frame;
	private JLabel clock;
	private static final int size_x = 550;
	private static final int size_y = 450;
	private ActionListener time;
	private Timer timer;
	private JButton button_OpenXML;
	private JTree tree;
	private JScrollPane scrollPane; 
	private File file_selected;
	
	/**
	 * Launch the application.
	 */
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

	public ex() {
		initialize();
	}
	
	protected class SLEEP {
		private int miliseconds = 0;
		public SLEEP(int miliseconds) {
			this.miliseconds = miliseconds;
		}
		
		public void method_sleep() {
			try {
				Thread.sleep(miliseconds);
			} catch (Exception new_exception) {
				JOptionPane.showMessageDialog(null, "Exceptie: " +new_exception+ ".", "ERROR 404", JOptionPane.ERROR_MESSAGE);
				frame.dispose();
			}
		}
	}
	
	public static void RECURSION(Node node,DefaultMutableTreeNode root) {
		NodeList temp;
		if(node.hasChildNodes() == true) {
			temp = node.getChildNodes();
			for(int i=0;i<temp.getLength();++i) {
				if((temp.item(i).getNodeType() == Node.ELEMENT_NODE) && (temp.item(i).getNodeName().trim().length() > 0)) {
					DefaultMutableTreeNode subroot = new DefaultMutableTreeNode(temp.item(i).getNodeName().trim());
					root.add(subroot);
					RECURSION(temp.item(i),subroot);
				} else if((temp.item(i).getNodeType() == Node.TEXT_NODE) && (temp.item(i).getNodeValue().trim().length() > 0)) {
						DefaultMutableTreeNode subroot = new DefaultMutableTreeNode(temp.item(i).getNodeValue().trim());
						root.add(subroot);
						RECURSION(temp.item(i),subroot);
				} 
			}
		}
	}
	
	private void initialize() {
		frame = new JFrame("Procesare XML");
		frame.setBounds(size_x/2+200, size_y/2, size_x, size_y);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setBackground(Color.DARK_GRAY);
		frame.setLayout(null);
		
		clock = new JLabel("");
		clock.setFont(new Font("Times New Roman", Font.BOLD, 22));
		clock.setLocation(size_x-105, size_y-410);
		clock.setSize(140, 24);
		frame.add(clock);
	
		DateFormat timeFormat = new SimpleDateFormat("HH:mm:ss");
		time = new ActionListener() {
			public void actionPerformed(ActionEvent event) {
				Date date = new Date();
				String main_time = timeFormat.format(date);
				clock.setText(main_time);
				}
			};
		
		button_OpenXML = new JButton("Open XML");
		button_OpenXML.setFont(new Font("Arial", Font.BOLD, 14));
		button_OpenXML.setFocusable(false);
		button_OpenXML.setLocation(size_x-520, size_y-415);
		button_OpenXML.setSize(120, 100/3);
		frame.getContentPane().add(button_OpenXML);
		
		scrollPane = new JScrollPane();
		scrollPane.setLocation(5, 90);
		scrollPane.setSize(527, 295);
		frame.add(scrollPane);
		
		
		button_OpenXML.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent event) {
				SLEEP sleep_instance = new SLEEP(2000);
				String hold_directory = System.getProperty("user.dir");
				JFileChooser fileChooser = new JFileChooser(hold_directory); //ma duce imd in directorul de la labul cutare
				fileChooser.setAcceptAllFileFilterUsed(false);
				fileChooser.addChoosableFileFilter(new FileNameExtensionFilter("XML Documents (*.xml)", "xml"));
				int result = fileChooser.showOpenDialog(null);
				if(result == JFileChooser.APPROVE_OPTION) {
					file_selected = fileChooser.getSelectedFile();
					String file_name = file_selected.getName();
					try {
						DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
						try {
							DocumentBuilder builder = factory.newDocumentBuilder();
							Document document = builder.parse(file_name);
							Element element = document.getDocumentElement();
							String hold_file = element.getTagName();
							System.out.print(hold_file+ "\n");
							
							
							String put_root = element.getTagName();
							DefaultMutableTreeNode root = new DefaultMutableTreeNode(put_root);
							DefaultTreeModel treeModel = new DefaultTreeModel(root);
							
							tree = new JTree(treeModel);
							scrollPane.setViewportView(tree);
							
							RECURSION(element, root);
						} catch(ParserConfigurationException new_exception_one) {
							JOptionPane.showMessageDialog(null, "Error 404 caused by exception" +new_exception_one+ ".", "ERROR 404", JOptionPane.ERROR_MESSAGE);
						}
					}catch (Exception new_exception) {
						JOptionPane.showMessageDialog(null, "Error 404 caused by exception" +new_exception+ ".", "ERROR 404", JOptionPane.ERROR_MESSAGE);
					}
				} else if(result == JFileChooser.CANCEL_OPTION) {
					sleep_instance.method_sleep();
				}
			}
		});		
		timer = new Timer(1000, time);
    	timer.setInitialDelay(0);
    	timer.start();
	}
}