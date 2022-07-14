package com.company;

import java.io.*;
import java.util.*;

public class Main {
    final private static String NAME_INPUT_FILE = "input.txt";
    final private static String NAME_OUTPUT_FILE = "output.csv";

    public static void main(String[] args) {
        Map<String, Integer> dictionary = new HashMap<String, Integer>();
        FileReader reader = null;
        try {
            reader = new FileReader(NAME_INPUT_FILE);
            int i = -1;
            StringBuilder s = new StringBuilder("");
            while ((i = reader.read()) != -1) {
                char ch = (char)i;
                if (Character.isLetterOrDigit(ch)) {
                    s.append(ch);
                    continue;
                }
                addDictionary(s, dictionary);
            }
            addDictionary(s, dictionary);
        }
        catch (IOException ex) {
            System.err.println("Ошибка в чтении файла: " + ex.getLocalizedMessage());
        }
        finally {
            if (reader != null) {
                try {
                    reader.close();
                }
                catch (IOException ex) {
                    ex.printStackTrace(System.err);
                }
            }
        }
        SortedSet<WordCount> answer = new TreeSet<>();
        int countWords = 0;
        for (Map.Entry<String, Integer> item : dictionary.entrySet()) {
            answer.add(new WordCount(item.getKey(), item.getValue()));
            countWords += item.getValue();
        }
        FileWriter writer = null;
        try {
            writer = new FileWriter(NAME_OUTPUT_FILE);
            String s;
            for (WordCount w : answer) {
                s = String.format("%s;%d;%.2f\n", w.getWord(), w.getCount(), 1.0 * w.getCount() / countWords);
                writer.write(s);
            }
        }
        catch (IOException ex) {
            System.err.println("Ошибка в записи файла: " + ex.getLocalizedMessage());
        }
        finally {
            if (writer != null) {
                try {
                    writer.close();
                }
                catch (IOException ex) {
                    ex.printStackTrace(System.err);
                }
            }
        }
    }

    private static void addDictionary(StringBuilder s, Map<String, Integer> dictionary) {
        if (s.length() != 0) {
            Integer value = dictionary.get(s.toString());
            if (value == null) {
                dictionary.put(s.toString(), 1);
            }
            else {
                dictionary.put(s.toString(), value + 1);
            }
            s.delete(0, s.length());
        }
    }
}
