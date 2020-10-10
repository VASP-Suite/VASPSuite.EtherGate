Feature: EIP-55 compliance
  
  As a developer
  I want to minimize the risks
  That I am working with a wrong Ethereum address

  Scenario Outline: Parsing valid Ethereum address
    When I call Parse method of the Address struct with a following parameter: "<addressString>"
    Then the Address.Parse call result should be "<addressBytes>"
    
    Examples: 
    | addressString                              | addressBytes                               |
    | 0x52908400098527886E0F7030069857D2E4169EE7 | 0x52908400098527886e0f7030069857d2e4169ee7 |
    | 0x8617E340B3D01FA5F11F306F4090FD50E238070D | 0x8617e340b3d01fa5f11f306f4090fd50e238070d |
    | 0xde709f2102306220921060314715629080e2fb77 | 0xde709f2102306220921060314715629080e2fb77 |
    | 0x27b1fdb04752bbc536007a920d24acb045561c26 | 0x27b1fdb04752bbc536007a920d24acb045561c26 |
    | 0x5aAeb6053F3E94C9b9A09f33669435E7Ef1BeAed | 0x5aaeb6053f3e94c9b9a09f33669435e7ef1beaed |
    | 0xfB6916095ca1df60bB79Ce92cE3Ea74c37c5d359 | 0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359 |
    | 0xdbF03B407c01E7cD3CBea99509d93f8DDDC8C6FB | 0xdbf03b407c01e7cd3cbea99509d93f8dddc8c6fb |
    | 0xD1220A0cf47c7B9Be7A2E6BA89F429762e7b9aDb | 0xd1220a0cf47c7b9be7a2e6ba89f429762e7b9adb |

  Scenario Outline: Parsing invalid Ethereum address
    When I call Parse method of the Address struct with a following parameter: "<addressString>"
    Then a FormatException will be thrown

    Examples:
    | addressString                              |
    | 0x52908400098527886e0F7030069857D2E4169EE7 |
    | 0x8617e340B3D01FA5F11F306F4090FD50E238070D |
    | 0xdE709f2102306220921060314715629080e2fb77 |
    | 0x27B1fdb04752bbc536007a920d24acb045561c26 |
    | 0x5AAeb6053F3E94C9b9A09f33669435E7Ef1BeAed |
    | 0xFB6916095ca1df60bB79Ce92cE3Ea74c37c5d359 |
    | 0xDbF03B407c01E7cD3CBea99509d93f8DDDC8C6FB |
    | 0xd1220A0cf47c7B9Be7A2E6BA89F429762e7b9aDb |

  Scenario Outline: Converting an Ethereum address to a string
    When I call ToString method of an Address "<addressBytes>" with a following parameter: "<addChecksum>"
    Then the ToString call result should be "<addressString>"

    Examples:
    | addressBytes                               | addChecksum | addressString                              |
    | 0x52908400098527886e0f7030069857d2e4169ee7 | true        | 0x52908400098527886E0F7030069857D2E4169EE7 |
    | 0x52908400098527886e0f7030069857d2e4169ee7 | false       | 0x52908400098527886e0f7030069857d2e4169ee7 |
    | 0x8617e340b3d01fa5f11f306f4090fd50e238070d | true        | 0x8617E340B3D01FA5F11F306F4090FD50E238070D |
    | 0x8617e340b3d01fa5f11f306f4090fd50e238070d | false       | 0x8617e340b3d01fa5f11f306f4090fd50e238070d |
    | 0xde709f2102306220921060314715629080e2fb77 | true        | 0xde709f2102306220921060314715629080e2fb77 |
    | 0xde709f2102306220921060314715629080e2fb77 | false       | 0xde709f2102306220921060314715629080e2fb77 |
    | 0x27b1fdb04752bbc536007a920d24acb045561c26 | true        | 0x27b1fdb04752bbc536007a920d24acb045561c26 |
    | 0x27b1fdb04752bbc536007a920d24acb045561c26 | false       | 0x27b1fdb04752bbc536007a920d24acb045561c26 |
    | 0x5aaeb6053f3e94c9b9a09f33669435e7ef1beaed | true        | 0x5aAeb6053F3E94C9b9A09f33669435E7Ef1BeAed |
    | 0x5aaeb6053f3e94c9b9a09f33669435e7ef1beaed | false       | 0x5aaeb6053f3e94c9b9a09f33669435e7ef1beaed |
    | 0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359 | true        | 0xfB6916095ca1df60bB79Ce92cE3Ea74c37c5d359 |
    | 0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359 | false       | 0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359 |
    | 0xdbf03b407c01e7cd3cbea99509d93f8dddc8c6fb | true        | 0xdbF03B407c01E7cD3CBea99509d93f8DDDC8C6FB |
    | 0xdbf03b407c01e7cd3cbea99509d93f8dddc8c6fb | false       | 0xdbf03b407c01e7cd3cbea99509d93f8dddc8c6fb |
    | 0xd1220a0cf47c7b9be7a2e6ba89f429762e7b9adb | true        | 0xD1220A0cf47c7B9Be7A2E6BA89F429762e7b9aDb |
    | 0xd1220a0cf47c7b9be7a2e6ba89f429762e7b9adb | false       | 0xd1220a0cf47c7b9be7a2e6ba89f429762e7b9adb |