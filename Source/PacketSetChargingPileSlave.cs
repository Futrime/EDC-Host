using System;

namespace EdcHost;

/// <summary>
/// A packet for slaves to set a charging pile.
/// </summary>
public class PacketSetChargingPileSlave : Packet
{
    #region Static, const and readonly fields.

    /// <summary>
    /// The packet ID.
    /// </summary>
    public const byte PacketId = 0x02;

    #endregion


    #region Constructors and finalizers.

    /// <summary>
    /// Construct a SetChargingPileSlave packet.
    /// </summary>
    public PacketSetChargingPileSlave()
    {
        // Empty
    }

    /// <summary>
    /// Construct a SetChargingPileSlave packet from a raw
    /// byte array.
    /// </summary>
    /// <param name="bytes">The raw byte array.</param>
    public PacketSetChargingPileSlave(byte[] bytes)
    {
        // Validate the packet and extract data.
        var data = Packet.ExtractPacketData(bytes);

        // Check the packet ID.
        byte packetId = bytes[0];
        if (packetId != PacketSetChargingPileSlave.PacketId)
        {
            throw new Exception("The packet ID is incorrect.");
        }
    }

    #endregion

    #region Methods.

    public override byte[] GetBytes()
    {
        var data = new byte[8];

        var header = Packet.GeneratePacketHeader(PacketSetChargingPileSlave.PacketId, data);

        var bytes = new byte[header.Length + data.Length];
        header.CopyTo(bytes, 0);
        data.CopyTo(bytes, header.Length);

        return bytes;
    }

    #endregion
}