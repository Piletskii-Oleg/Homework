#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct DSNode
{
	int key;
	int data;
	struct DSNode* left, * right;
};

void printTree(struct DSNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->left, offset + 3);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printTree(root->right, offset + 3);
	printf("Key %d -> %d", root->key, root->data);
}

int main()
{

}
