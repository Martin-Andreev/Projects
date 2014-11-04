package com.game;

import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.image.BufferStrategy;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

import javax.imageio.ImageIO;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

import com.game.input.Keyboard;

public class Game extends Canvas implements Runnable {

	private static final long serialVersionUID = 1L;
	public static final int WIDTH = 900;
	public static final int HEIGHT = WIDTH / 16 * 9;
	public static final String TITLE = "SPACE SURVIVOR";

	public static Graphics g;
	public static BufferStrategy bs;

	public static int levels = 1;
	public static int spawnRate = 95;
	public static int speedRate = 2;

	private boolean isInNenuState = true;
	public static boolean isRunning = false;
	public static boolean isWaitingAfterDeath = false;

	private Thread thread;
	private JFrame frame;
	private Keyboard keyboard;
	private Image back = new ImageIcon("res\\back.png").getImage();
	private Image menu = new ImageIcon("res\\menu.png").getImage();

	public static Ship ship = new Ship(420, 300, 64, new File(
			"res\\spaceship.png"));

	public static ArrayList<Asteroid> asteroids = new ArrayList<Asteroid>();
	public static ArrayList<Bullet> bullets = new ArrayList<Bullet>();

	public static long overalScore = 0;
	public static long levelScore = 0;
	public String highScore = "";

	public Game() {
		Dimension size = new Dimension(WIDTH, HEIGHT);
		setPreferredSize(size);

		frame = new JFrame();
		keyboard = new Keyboard();

		addKeyListener(keyboard);

		frame.setResizable(false);
		frame.setTitle(TITLE);
		frame.add(this);
		frame.pack();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLocationRelativeTo(null);
		frame.setVisible(true);
	}
	
	//Sounds loading
	
	public static void playSound(String fileName) {
		try {
			Clip clip = AudioSystem.getClip();
			clip.open(AudioSystem.getAudioInputStream(new File(fileName)));
			clip.start();
		} catch (Exception exc) {
			exc.printStackTrace(System.out);
		}
	}

	//Score drawings on the screen
	
	private void drawScore(Graphics g) {
		g.setColor(Color.WHITE);
		g.setFont(new Font("verdana.ttf", Font.BOLD, 14));
		g.drawString("Level: " + levels, 10, 20);
		g.drawString("Score: " + overalScore, 10, Game.HEIGHT - 27);
		g.drawString("Highscore: " + highScore, 10, Game.HEIGHT - 10);
	}

	//Reads the high score if there is any
	
	public String getHighScore() throws IOException {
		FileReader readFile = null;
		BufferedReader reader = null;
		try {
			readFile = new FileReader("highscore.txt");
			reader = new BufferedReader(readFile);
			String line = reader.readLine();
			return line;
		} catch (FileNotFoundException e) {
			return "Nobody: 0";
		} finally {
			try {
				if (reader != null) {
					reader.close();
				}
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	//Checks if there is high score
	
	public void checkScore() {
		if (overalScore > Integer.parseInt(highScore.split(": ")[1])) {
			String name = JOptionPane
					.showInputDialog("NEW HIGHSCORE! Type your name: ");
			highScore = name + ": " + overalScore;

			File scoreFile = new File("highscore.txt");
			if (!scoreFile.exists()) {
				try {
					scoreFile.createNewFile();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}

			FileWriter writeFile = null;
			BufferedWriter writer = null;

			try {
				writeFile = new FileWriter(scoreFile);
				writer = new BufferedWriter(writeFile);
				writer.write(this.highScore);
			} catch (Exception e) {
				e.printStackTrace();
			} finally {
				if (writer != null) {
					try {
						writer.close();
					} catch (IOException e) {
						e.printStackTrace();
					}
				}
			}
		}
	}

	//Drawing the graphics when the game is over
	
	private void gameOver(Graphics g) {
		g = getGraphics();
		g.setColor(Color.RED);
		g.drawImage(ship.getImage(), ship.getX(), ship.getY(), null);
		g.setFont(new Font("verdana.ttf", Font.BOLD, 50));
		g.drawString("GAME OVER", 295, 150);
		g.setColor(Color.WHITE);
		g.setFont(new Font("verdana.ttf", Font.BOLD, 25));
		g.drawString("Press Y to restart the game or E to exit!", 220, 200);
	}
	
	//Drawing the Menu graphics
	
	private void menu(Graphics g) {
		g = getGraphics();
		g.drawImage(menu, 0, 0, null);
	}
	
	public synchronized void start() {
		isRunning = true;
		thread = new Thread(this, TITLE);
		thread.start();
	}

	public synchronized void stop() {
		isRunning = false;

		try {
			thread.join();
			start();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
	
	//The Update loop
	
	private void update() {
		keyboard.update();

		ship.update(keyboard);

		Asteroid.spawn();

		for (int i = 0; i < asteroids.size(); i++) {
			Asteroid a = asteroids.get(i);
			if (a.getY() > Game.HEIGHT) {
				asteroids.remove(i);
				break;
			}
			a.update(i);
		}

		for (int i = 0; i < bullets.size(); i++) {
			Bullet b = bullets.get(i);
			if (b.getY() < -30) {
				bullets.remove(i);
				break;
			}
			b.update(i);
		}
	}

	//The Render loop
	
	private void render() {
		bs = getBufferStrategy();
		if (bs == null) {
			createBufferStrategy(4);
			return;
		}

		g = bs.getDrawGraphics();

		if (isWaitingAfterDeath) {
			checkScore();
			gameOver(g);
			return;
		}

		if (isInNenuState) {
			menu(g);
			return;
		}

		g.drawImage(back, 0, 0, null);

		drawScore(g);
		ship.render(g);

		for (int i = 0; i < asteroids.size(); i++) {
			asteroids.get(i).render(g);
		}

		for (int i = 0; i < bullets.size(); i++) {
			bullets.get(i).render(g);
		}

		if (highScore.equals("")) {
			try {
				highScore = this.getHighScore();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		g.dispose();
		bs.show();
	}

	public void run() {
		long lastTime = System.nanoTime();
		long timer = System.currentTimeMillis();
		final double ns = 1000000000.0 / 60;
		double delta = 0;
		int frames = 0;
		int updates = 0;

		requestFocus();
		while (isRunning) {
			long now = System.nanoTime();
			delta += (now - lastTime) / ns;
			lastTime = now;
			keyboard.update();
			if (keyboard.start) {
				isInNenuState = false;
			}

			if (keyboard.pause) {
				isInNenuState = true;
			}

			if (keyboard.restart) {
				isWaitingAfterDeath = false;
				bullets.clear();
				asteroids.clear();
				ship.setX(420);
				ship.setY(300);
				overalScore = 0;
				levels = 1;
				levelScore = 0;
				spawnRate = 95;
				speedRate = 2;
				try {
					Game.ship.setImage(ImageIO.read(new File(
							"res\\spaceship.png")));
				} catch (IOException e) {
					e.printStackTrace();
				}
			}

			if (keyboard.exit) {
				frame.dispose();
				thread.stop();
			}
			if (delta >= 1)
				while (delta >= 1) {

					if (isInNenuState || isWaitingAfterDeath) {
						render();
					} else {
						update();
						render();
					}
					delta--;
					updates++;
					frames++;
				}
			else
				try {
					Thread.sleep(1);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}

			if (System.currentTimeMillis() - timer > 1000) {
				timer += 1000;
				updates = 0;
				frames = 0;
			}
		}
		stop();
	}

	public static void main(String[] args) {
		new Game().start();
	}
}
