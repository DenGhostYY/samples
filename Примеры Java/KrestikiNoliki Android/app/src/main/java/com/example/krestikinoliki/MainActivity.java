package com.example.krestikinoliki;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity {
    private final int N = 3;
    private final int FreeCell = 0;
    private final int KrestikCell = 1;
    private final int NolikCell = -1;
    private boolean isMoveKrestik = true;
    private boolean isGameOver = false;
    private int[][] field = new int[N][N];
    private int countFreeCells = N*N;
    private int[][] idCells = new int[][] {{R.id.cell_0_0, R.id.cell_0_1, R.id.cell_0_2},
                    {R.id.cell_1_0, R.id.cell_1_1, R.id.cell_1_2},
                    {R.id.cell_2_0, R.id.cell_2_1, R.id.cell_2_2}};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    private boolean isWin(int iM, int jM) {
        int sum = 0;
        for (int i = 0; i < N; i++) {
            sum += field[i][jM];
        }
        if (Math.abs(sum) == N) {
            return true;
        }

        sum = 0;
        for (int j = 0; j < N; j++) {
            sum += field[iM][j];
        }
        if (Math.abs(sum) == N) {
            return true;
        }

        sum = 0;
        for (int j = 0; j < N; j++) {
            int i = j + iM - jM;
            if (i >= 0 && i < N) {
                sum += field[i][j];
            }
        }
        if (Math.abs(sum) == N) {
            return true;
        }

        sum = 0;
        for (int j = 0; j < N; j++) {
            int i = -j + iM + jM;
            if (i >= 0 && i < N) {
                sum += field[i][j];
            }
        }
        if (Math.abs(sum) == N) {
            return true;
        }
        return false;
    }

    public void clickNewGame(View view) {
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                field[i][j] = FreeCell;
                ImageButton cell = findViewById(idCells[i][j]);
                cell.setImageResource(R.drawable.empty_cell);
            }
        }
        Button newGame = findViewById(R.id.newGameButton);
        newGame.setEnabled(false);

        TextView status = findViewById(R.id.statusTextView);
        status.setText(R.string.krestiki);

        isGameOver = false;
        isMoveKrestik = true;
        countFreeCells = N*N;
    }

    public void clickCell(View view) {
        if (isGameOver) {
            return;
        }
        ImageButton cell = (ImageButton) view;
        TextView status = findViewById(R.id.statusTextView);
        int idCell = cell.getId();
        int i = 0, j = 0;
        for (i = 0; i < N; i++) {
            for (j = 0; j < N; j++) {
                if (idCells[i][j] == idCell) {
                    break;
                }
            }
            if (j < N) {
                break;
            }
        }
        /*Toast toast = Toast.makeText(getApplicationContext(),
                String.valueOf(i) + " " + String.valueOf(j), Toast.LENGTH_SHORT);
        toast.show();*/
        if (field[i][j] != 0) {
            return;
        }
        if (isMoveKrestik) {
            cell.setImageResource(R.drawable.krestik);
            field[i][j] = KrestikCell;
        }
        else {
            cell.setImageResource(R.drawable.nolik);
            field[i][j] = NolikCell;
        }
        countFreeCells -= 1;
        boolean win = isWin(i, j);
        if (win) {
            if (isMoveKrestik) {
                status.setText(R.string.winKrestiki);
            }
            else {
                status.setText(R.string.winNoliki);
            }
            Button newGame = findViewById(R.id.newGameButton);
            newGame.setEnabled(true);
            isGameOver = true;
            return;
        }
        else if (countFreeCells == 0) {
            status.setText(R.string.nichya);
            Button newGame = findViewById(R.id.newGameButton);
            newGame.setEnabled(true);
            isGameOver = true;
            return;
        }
        else if (isMoveKrestik) {
            status.setText(R.string.noliki);
        }
        else {
            status.setText(R.string.krestiki);
        }
        isMoveKrestik = !isMoveKrestik;
    }
}