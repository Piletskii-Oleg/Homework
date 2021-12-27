#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct AVLNode
{
	int key, data;
	struct AVLNode* left, * right;

	int height;
	struct AVLNode* parent;
};

void print_all(struct AVLNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->right, offset + 3);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printf("%d->%d\n", root->key, root->data);
	printTree(root->left, offset + 3);
}

int main()
{

}
