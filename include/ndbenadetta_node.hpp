#ifndef __BENADETTA_NODE_H__
#define __BENADETTA_NODE_H__

enum class TraversOrder {
    Preorder,
    Inorder,
    Postorder,
    ListOrder,
    ReservListOrder
};

template <typename T, class TNode, int TSIZES = 2>
class benadetta_node {
public:
    using node_type = TNode;
    using data_type = T;
    using this_t = benadetta_node<data_type, node_type, TSIZES>;


    benadetta_node(const char name) 
        : m_strName(name) { }

    virtual void travers(TraversOrder order, TNode Root) = 0;
    virtual void travers(TraversOrder order, int (*traversFunc)(TNode* node), TNode Root) = 0;

    data_type get_entry() { return m_tData; }
protected:
    data_type    m_tData;
    node_type    m_arNodes[TSIZES];

    const char m_strName[32];
};

#endif