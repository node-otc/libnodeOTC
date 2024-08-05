#ifndef __BENADETTA_BLOCKNODE_ENTRY_H__
#define __BENADETTA_BLOCKNODE_ENTRY_H__

#include <string>
#include <ctime>

class benadetta_block_entry {
public:
    using owner_type = void*;

    benadetta_block_entry (double data, std::string creater);
    benadetta_block_entry (double data, std::string hash, std::string creater);
    benadetta_block_entry(const benadetta_block_entry& other);

protected:
    std::string update();
protected:
    virtual std::string calc_hash(std::string data) = 0;

private:
    double m_dWert;
    std::string m_guidEID;
    std::time_t m_timeStamp;
    std::string m_strHash;
    std::string m_strLastHash;
    std::string m_strTransHash;
    std::string m_strCreaterHash;
    owner_type*  m_lTransfers;
};

class benadetta_block_entry_sha512 : public benadetta_block_entry {
public:
    using this_type = benadetta_block_entry_sha512;
    using base_type = benadetta_block_entry;

    benadetta_block_entry_sha512 (double data, std::string creater) 
        : benadetta_block_entry(data, creater) { }
    benadetta_block_entry_sha512 (double data, std::string hash, std::string creater) 
        : benadetta_block_entry(data, hash, creater) { }
    benadetta_block_entry_sha512(const benadetta_block_entry& other) 
        : benadetta_block_entry(other) { }
protected:
    virtual std::string calc_hash(std::string data);
};

#endif