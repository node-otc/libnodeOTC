#!/bin/bash

sudo rm -r build
mkdir build
cd build

cmake .. -DCMAKE_C_COMPILER=clang -DCMAKE_CXX_COMPILER=clang++ -DLLVM_DIR="$(llvm-config --cmakedir)" -GNinja 

ninja -v
