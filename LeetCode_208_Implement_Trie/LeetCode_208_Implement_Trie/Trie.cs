namespace LeetCode_208_Implement_Trie
{
    public class Trie<T>
    {
        /** Initialize your data structure here. */

        private Node<T> _head { get; set; }

        public Trie()
        {
            _head = new Node<T>();
        }

        /** Inserts a word into the trie. */

        public void Insert(string word, T val)
        {
            Insert(null, word, val, 0);
        }

        private void Insert(Node<T> root, string word, T val, int position)
        {
            if (position == word.Length)
            {
                root.Value = val;
                return;
            }
            if (root is null)
            {
                root = _head;
            }
            var newRoot = new Node<T>();
            root.Refs[(int)word[position]] = newRoot;
            Insert(newRoot, word, val, position + 1);
        }

        /** Returns if the word is in the trie. */

        public T Search(string word)
        {
            return Search(null, word, 0);
        }

        private T Search(Node<T> root, string word, int position)
        {
            if (position == word.Length)
            {
                return root is null ? default(T) : root.Value;
            }
            if (root is null)
            {
                root = _head;
            }
            var newRoot = root.Refs[word[position]];
            return Search(newRoot, word, position + 1);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */

        public bool StartsWith(string prefix)
        {
            return StartsWith(null, prefix, 0);
        }

        private bool StartsWith(Node<T> root, string prefix, int position)
        {
            if (position == prefix.Length)
            {
                return root is null ? false : true;
            }
            if (root is null)
            {
                root = _head.Refs[prefix[position]];
            }
            return StartsWith(root, prefix, position + 1);
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */

    public class Node<T>
    {
        private const int _size = 256;
        public Node<T>[] Refs = new Node<T>[_size];
        public T Value;

        public Node()
        {
            Value = default(T);
        }

        public Node(T val)
        {
            Value = val;
        }
    }
}