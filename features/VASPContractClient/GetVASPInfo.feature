Feature: Get VASP info
  
  Background:
    Given VASPIndex smart contract was deployed
      And VASP with a code c28d7646 created a VASP contract
      And VASP set its contract channels to 0x00000001
      And VASP set its contract message key to 0x030b92658a44acd5d608be37beecc15e6c2c3c80215f8f1ae20cd6292e1f20fe4d
      And VASP set its contract signing key to 0x02196d0b08a258f6a8041c867d248cab1dcdef473e5069cdb15c64b7998449594a
      And VASP set its contract transport key to 0x02a780672d5d7ce6ae295908eb43b3831fe6d0d0341555b1be40526a0da5e954c2
      And then 100 blocks were mined
      And VASP set its contract message key to 0x0224c8cc4021e06ef493157f5be5358bfc2ca180534b3cfa49281e1647bc7e2373
      And VASP set its contract signing key to 0x03047107117e5c30ec0dfe00ef3e15e3940734e751cf9d38610ed4c8797383a75a
      And VASP set its contract transport key to 0x03e09bd332934bab62b79c943fd274e8b41f969c11b4d41f19401e2efd383a1a23

  Scenario Outline: Calling GetChannelsAsync method of a VASPContractClient
    When I call GetChannelsAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the GetChannelsAsync call result should be "<channels>"
    
    Examples:
    | minimalConfirmationLevel | channels   |
    | 0                        | 0x00000001 |
    | 100                      | 0x00000001 |

  Scenario Outline: Calling GetMessageKeyAsync method of a VASPContractClient
    When I call GetMessageKeyAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the GetMessageKeyAsync call result should be "<messageKey>"

    Examples:
    | minimalConfirmationLevel | messageKey                                                           |
    | 0                        | 0x0224c8cc4021e06ef493157f5be5358bfc2ca180534b3cfa49281e1647bc7e2373 |
    | 100                      | 0x030b92658a44acd5d608be37beecc15e6c2c3c80215f8f1ae20cd6292e1f20fe4d |

  Scenario Outline: Calling GetSigningKeyAsync method of a VASPContractClient
    When I call GetSigningKeyAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the GetSigningKeyAsync call result should be "<signingKey>"

    Examples:
    | minimalConfirmationLevel | signingKey                                                           |
    | 0                        | 0x03047107117e5c30ec0dfe00ef3e15e3940734e751cf9d38610ed4c8797383a75a |
    | 100                      | 0x02196d0b08a258f6a8041c867d248cab1dcdef473e5069cdb15c64b7998449594a |

  Scenario Outline: Calling GetTransportKeyAsync method of a VASPContractClient
    When I call GetTransportKeyAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the GetTransportKeyAsync call result should be "<transportKey>"

    Examples:
    | minimalConfirmationLevel | transportKey                                                         |
    | 0                        | 0x03e09bd332934bab62b79c943fd274e8b41f969c11b4d41f19401e2efd383a1a23 |
    | 100                      | 0x02a780672d5d7ce6ae295908eb43b3831fe6d0d0341555b1be40526a0da5e954c2 |

  Scenario Outline: Calling GetVASPCodeAsync method of a VASPContractClient
    When I call GetVASPCodeAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the GetVASPCodeAsync call result should be "<vaspCode>"

    Examples:
    | minimalConfirmationLevel | vaspCode |
    | 0                        | c28d7646 |
    | 100                      | c28d7646 |

  Scenario Outline: Calling GetVASPInfoAsync method of a VASPContractClient
    When I call GetVASPInfoAsync method of a VASPContractClient with a following parameter: "<minimalConfirmationLevel>"
    Then the Channels property of the GetVASPInfoAsync call result should be "<channels>"
     And the VASPCode property of the GetVASPInfoAsync call result should be "<vaspCode>"
     And the MessageKey property of the GetVASPInfoAsync call result should be "<messageKey>"
     And the SigningKey property of the GetVASPInfoAsync call result should be "<signingKey>"
     And the TransportKey property of the GetVASPInfoAsync call result should be "<transportKey>"
    
    Examples:
    | minimalConfirmationLevel | channels   | vaspCode | messageKey                                                           | signingKey                                                           | transportKey                                                         |
    | 0                        | 0x00000001 | c28d7646 | 0x0224c8cc4021e06ef493157f5be5358bfc2ca180534b3cfa49281e1647bc7e2373 | 0x03047107117e5c30ec0dfe00ef3e15e3940734e751cf9d38610ed4c8797383a75a | 0x03e09bd332934bab62b79c943fd274e8b41f969c11b4d41f19401e2efd383a1a23 |
    | 100                      | 0x00000001 | c28d7646 | 0x030b92658a44acd5d608be37beecc15e6c2c3c80215f8f1ae20cd6292e1f20fe4d | 0x02196d0b08a258f6a8041c867d248cab1dcdef473e5069cdb15c64b7998449594a | 0x02a780672d5d7ce6ae295908eb43b3831fe6d0d0341555b1be40526a0da5e954c2 |
    