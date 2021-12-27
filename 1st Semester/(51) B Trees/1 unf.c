#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS
#define N 4

struct BTNode;

struct Item
{
	int key;
	int data;
	struct BTNode* down;
};

struct BTNode
{
	int sonAmount;
	struct Item array[N];
};

struct BTTree
{
	struct BTNode* root;
	int height;
};

struct BTTree* create()
{
	struct BTTree* newNode = (struct BTTree*)malloc(sizeof(struct BTTree));
	newNode->root = (struct BTNode*)malloc(sizeof(struct BTNode));
	newNode->root->sonAmount = 0;

}

int main()
{

}
