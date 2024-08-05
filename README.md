# BENADETTA libnodeOTC 
libnodeOTC is the main libary for the Benadetta OT(T)C (Overlay Trusted Tiny Coin ) System. 

## build
Prerequisites:
- CMake 3.24
- Clang 18
- Ninja

```c
mkdir build
cd build

cmake .. -DCMAKE_C_COMPILER=clang -DCMAKE_CXX_COMPILER=clang++ -DLLVM_DIR="$(llvm-config --cmakedir)" -GNinja 

ninja
```

## Install

```c
sudo ninja install
```

