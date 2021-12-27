#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct BSNode
{
	int data, key;
	struct BSNode* left, * right;
};

struct BSNode* newTree(int key, int data, struct BSNode* left, struct BSNode* right)
{
	struct BSNode* root = (struct BSNode*)malloc(sizeof(struct BSNode));
	root->key = key;
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(struct BSNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->right, offset + 5);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printf("%d->%d\n", root->key, root->data);
	printTree(root->left, offset + 5);
}

struct BSNode* search(struct BSNode* root, int key)
{
	if (!root)
		return;
	if (root->key == key)
		return root;

	while (!root || root->key != key)
	{
		if (data < root->key)
		{
			if (root->right)
				root = root->left;
			else
				break;
		}
		else
		{
			if (root->left)
				root = root->right;
			else
				break;
		}
	}

	if (root->key == key)
		return root;
	else
		return NULL;
}

int main()
{

}
