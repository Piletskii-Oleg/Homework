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

int correct_height(struct AVLNode* root)
{
	if (!root)
		return 0;

	if (root->left && root->right)
	{
		root->height = max(correct_height(root->left), correct_height(root->right)) + 1;
	}
	else if (root->left)
	{
		root->height = correct_height(root->left) + 1;
	}
	else if (root->right)
	{
		root->height = correct_height(root->right) + 1;
	}
	else
	{
		return 1;
	}
	return root->height;
}

int defect_height(struct AVLNode* root)
{
	return correct_height(root->right) - correct_height(root->left);
}

void print(struct AVLNode* root)
{
	printf("Pointer to the node: %p\n", root);
	printf("Height of the node: %d\n", root->height);
	printf("Key->Data: %d->%d\n", root->key, root->data);

	if (root->right && root->left)
	{
		printf("Left son and right son key->data: %d->%d, %d->%d",
			root->right->key, root->right->data, root->left->key, root->left->data);
	}
	else if (root->right)
	{
		printf("Right son key->data: %d->%d", root->right->key, root->right->data);
	}
	else if (root->right)
	{
		printf("Left son data: %d->%d", root->left->key, root->left->data);
	}
	else
	{
		printf("The current node is a leaf.");
	}
}

int main()
{

}
