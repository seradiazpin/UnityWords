using System;

[Serializable]
public class Word{

	public Word(string text, int points){
		this.Text = text;
		this.Points = points;
	}
	public string Text;
	public int Points;


	public string ToString(){
		return Text;
	}
}
