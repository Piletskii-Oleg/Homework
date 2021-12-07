#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

void writesins(char path[]) //corrupts the stack around currentFile and current Sin
{
    FILE* fptr;
    char originalPath[100];
    strcpy(originalPath, path);
    char currentFile[10];
    char currentSin[3];

    for (double i = 0.1; i <= 1; i += 0.1)
    {
        strcpy(currentFile, "sin_");
        sprintf(currentSin, "%lf", i);

        strcat(currentFile, currentSin);
        strcat(currentFile, ".txt");

        strcpy(path, originalPath);
        strcat(path, currentFile);
        fptr = fopen(path, "w");


        fprintf(fptr, "%s", "x\t\tsin(x)\n");
        for (double j = 0.0; j <= 20.0; j += i)
        {
            fprintf(fptr, "%lf\t%lf\n", j, sin(j));
        }
        fclose(fptr);
    }
}

int main()
{
    char path[100] = "C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\";
    char path2[100] = "C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\g.txt";
    writesins(path);
}
