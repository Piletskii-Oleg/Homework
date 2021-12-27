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

struct AVLNode* newTree(int data, struct AVLNode* left, struct AVLNode* right)
{
	struct AVLNode* root = (struct AVLNode*)malloc(sizeof(struct AVLNode));
	root->height = 0;
	root->key = 1;
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(struct AVLNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->right, offset + 3);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printf("%d\n", root->data);
	printTree(root->left, offset + 3);
}

void insert(struct AVLNode** rootRef, int data)
{
	if (*rootRef == NULL)
	{
		struct AVLNode* newNode = (struct AVLNode*)malloc(sizeof(struct AVLNode));
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

void rotate_left(struct AVLNode** rootRef, struct AVLNode** rotateRef)
{
	struct AVLNode* saveLeft = (*rotateRef)->right;
	(*rotateRef)->right = (*rootRef)->right->left;
	if (!(*rotateRef)->parent)
		saveLeft->left = (*rotateRef);
	else if ((*rotateRef) == (*rotateRef)->parent->left)
		(*rotateRef)->parent->left = saveLeft;
	else
		(*rotateRef)->parent->right = saveLeft;

	saveLeft->left = (*rotateRef);
}

int main()
{

}
