#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct BNode
{
	int data;
	struct BNode* left, * right;
};

int grandsonAmount(struct BNode* root)
{
	if (root == NULL)
		return 0;

	int amount = 0;
	if (root->right->right)
		amount++;
	if (root->right->left)
		amount++;
	if (root->left->right)
		amount++;
	if (root->left->left)
		amount++;
	return amount;
}

int main()
{
	return 0;
}
