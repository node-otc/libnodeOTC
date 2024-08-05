#include "ndbenadetta_block_entry.hpp"

benadetta_block_entry::benadetta_block_entry (double data, std::string creater) {
            m_dWert = data;
            m_guidEID = creater;
            m_timeStamp = std::time(0);
            m_strHash = "NO_HASH";
            m_strLastHash = "";
            m_strTransHash = "";
            m_strCreaterHash = "";
            m_lTransfers = nullptr;
            
            update ();

            //Owners = new GenericBlockOwnerList(m_strHash, new GenericBlockOwnerListEntry(Hash, m_guidEID, m_timeStamp));
        }
benadetta_block_entry::benadetta_block_entry (double data, std::string hash, std::string creater) {
            m_dWert = data;
            m_guidEID = creater;
            m_timeStamp = std::time(0);
            m_strHash = hash;
            m_strLastHash = "";
            m_strTransHash = "";
            m_strCreaterHash = "";
            m_lTransfers = nullptr;

            //Owners = new GenericBlockOwnerList(m_strHash, new GenericBlockOwnerListEntry(m_strHash, m_guidEID, m_timeStamp));
        }

benadetta_block_entry::benadetta_block_entry(const benadetta_block_entry& other) {
        m_dWert = other.m_dWert;
        m_guidEID = other.m_guidEID;
        m_timeStamp = other.m_timeStamp;
        m_strHash = other.m_strHash;
        m_strLastHash = other.m_strLastHash;
        m_strTransHash = other.m_strTransHash;
        m_strCreaterHash = other.m_strCreaterHash;
        m_lTransfers = other.m_lTransfers;
    }
std::string benadetta_block_entry::update() {
    std::string data = std::to_string(m_dWert) + "-" + m_guidEID + "-" + std::to_string(m_timeStamp) + 
                       "-" + m_strLastHash + ":" + m_strCreaterHash;

    std::string hash = calc_hash(data);

    return hash;
}
