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

void insert(struct BSNode** rootRef, int data)
{
	if (*rootRef == NULL)
	{
		struct BSNode* newNode = (struct BSNode*)malloc(sizeof(struct BSNode));
		newNode->left = NULL;
		newNode->right = NULL;
		newNode->data = data;
		*rootRef = newNode;
	}
	else
	{
		if (data < (*rootRef)->data)
			insert(&(*rootRef)->left, data);
		else
			insert(&(*rootRef)->right, data);
	}
}

int main()
{
	struct BSNode* tree = NULL;
	insert(&tree, 3);
	insert(&tree, 5);
	insert(&tree, 9);
	insert(&tree, 1);
	insert(&tree, 4);
	printTree(tree, 3);
	printf("%X", search(tree, 5));
}
