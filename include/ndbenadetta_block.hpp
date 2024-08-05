#ifndef __BENADETTA_BLOCKNODE_H__
#define __BENADETTA_BLOCKNODE_H__

#include "ndbenadetta_node.hpp"
#include "ndbenadetta_block_entry.hpp"


template <typename T, class TEntry = benadetta_block_entry>
class benadetta_block_node : public benadetta_node<T, benadetta_block_node<T, TEntry, 3>> {
public:
    using this_type = benadetta_block_node<T, TEntry>
    using entry_type = TEntry;
    using node_type = benadetta_node<T, benadetta_block_node<T, entry_type, 3> >;
    using value_type = T;
    using reference = T&;
    using pointer = T*;
    using const_ptr = const T*;
    using const_ref = const T&;

    bool is_valid() {
        return m_entry.is_valid();
    }
protected:
    entry_type m_entry;
};

#endif