#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct BSNode
{
	int data;
	struct BSNode* left, * right;
};

struct BSNode* newTree(int data, struct BSNode* left, struct BSNode* right)
{
	struct BSNode* root = (struct BSNode*)malloc(sizeof(struct BSNode));
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(struct BSNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->right, offset + 3);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printf("%d\n", root->data);
	printTree(root->left, offset + 3);
}

struct BSNode* search(struct BSNode* root, int data)
{
	if (!root)
		return 0;
	if (root->data == data)
		return root;

	if (data > root->data)
		return search(root->right, data);
	else
		return search(root->left, data);
}

int main()
{

}
