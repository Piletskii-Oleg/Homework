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

struct BSNode* minValueNode(struct BSNode* root)
{
	while (root && root->left)
	{
		root = root->left;
	}
	return root;
}

void deleteVoid(struct BSNode* root, struct BSNode* saveroot, int data)
{
	if (!root)
		return;

	if (data < root->data)
		deleteVoid(root->left, root, data);
	else if (data > root->data)
		deleteVoid(root->right, root, data);
	else
	{
		if (!root->left && !root->right)
		{
			if (root->data < saveroot->data)
				saveroot->left = NULL;
			else
				saveroot->right = NULL;

			free(root);
			root = NULL;
		}
		else if (!root->right)
		{
			root->data = root->left->data;
			free(root->left);
			root->left = NULL;
		}
		else if (!root->left)
		{
			root->data = root->right->data;
			free(root->right);
			root->right = NULL;
		}
		else
		{
			if (!root->right->left)
			{
				root->data = root->right->data;
				root->right = root->right->right;
				return;
			}
			else
			{
				struct BSNode* temp = minValueNode(root->right);
				root->data = temp->data;
				deleteVoid(root->right, root, temp->data);
			}
		}
	}
}

struct BSNode* deleteNode(struct BSNode* root, int data)
{
	if (!root)
		return NULL;

	if (data < root->data)
	{
		root->left = deleteNode(root->left, data);
	}
	else if (data > root->data)
	{
		root->right = deleteNode(root->right, data);
	}
	else
	{
		if (!root->left && !root->right)
		{
			free(root);
			return NULL;
		}
		else if (!root->left)
		{
			struct BSNode* temp = root->right;
			free(root);
			return temp;
		}
		else if (!root->right)
		{
			struct BSNode* temp = root->left;
			free(root);
			return temp;
		}
		else
		{
			int rightMin = minValueNode(root->right)->data;
			root->data = rightMin;
			root->right = deleteNode(root->right, rightMin);
		}
	}
	return root;
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

	tree = deleteNode(tree, 3);
	deleteVoid(tree, tree, 9);
	printf("\n\n");
	printTree(tree, 3);
}
