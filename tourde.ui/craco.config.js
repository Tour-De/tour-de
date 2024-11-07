const path = require('path');

module.exports = {
  webpack: {
    alias: {
      '@assets': path.resolve(__dirname, 'src/assets/'),
      '@components': path.resolve(__dirname, 'src/components/'),
      '@hooks': path.resolve(__dirname, 'src/hooks/'),
      '@pages': path.resolve(__dirname, 'src/pages/'),
      '@util': path.resolve(__dirname, 'src/util/'),
      '@models': path.resolve(__dirname, 'src/models/'),
    },
  },
  jest: {
    configure: {
      moduleNameMapper: {
        '^@assets(.*)$': '<rootDir>/src/assets$1',
        '^@components(.*)$': '<rootDir>/src/components$1',
        '^@hooks(.*)$': '<rootDir>/src/hooks$1',
        '^@pages(.*)$': '<rootDir>/src/pages$1',
        '^@util(.*)$': '<rootDir>/src/util$1',
        '^@models(.*)$': '<rootDir>/src/models$1',
      },
    },
  },
};
