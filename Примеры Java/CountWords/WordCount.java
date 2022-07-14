package com.company;

public class WordCount implements Comparable<WordCount> {
    private String word;
    private int count;

    public WordCount(String word, int count) {
        this.word = word;
        this.count = count;
    }
    public String getWord() {
        return word;
    }
    public int getCount() {
        return count;
    }
    @Override
    // по убыванию частоты
    public int compareTo(WordCount w) {
        if (count > w.count) {
            return -1;
        }
        else if (count == w.count) {
            return 0;
        }
        return 1;
    }
}
