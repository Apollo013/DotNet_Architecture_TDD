using Application.NUnit.Domain.Partitioning;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application.NUnit.Domain.Tests.Partitioning_Tests
{
    /*
     * Demosntrates how to categorize tests, use of setup to initialise test wide variables, and the 3 A's of testing.
     */

    [Category("Partitioning_Tests")]
    [TestFixture]
    public class When_Partitioning_Shares
    {
        List<Share> _sharesList;

        [SetUp]
        public void SetupTest()
        {
            _sharesList = CreateSharesListOfSize(4);
        }

        [Test]
        public void Partitioning_a_list_of_one_item_by_one_produces_a_partition_of_size_one()
        {
            // Arrange
            List<Share> sharesList = CreateSharesListOfSize(1);
            Partitioner partitioner = new Partitioner(1);

            // Act
            Partition partition = partitioner.Partition(sharesList);

            // Assert
            Assert.AreEqual(1, partition.Size);
        }

        [Test]
        public void Partitioning_a_list_of_two_items_by_one_produces_a_partition_of_size_two()
        {
            // Arrange
            List<Share> sharesList = CreateSharesListOfSize(2);
            Partitioner partitioner = new Partitioner(1);

            // Act
            Partition partition = partitioner.Partition(sharesList);

            // Assert
            Assert.AreEqual(2, partition.Size);
        }

        [Test]
        public void Partitioning_a_list_of_four_items_by_one_produces_a_partition_of_size_four()
        {
            // Arrange
            Partitioner partitioner = new Partitioner(1);

            // Act
            Partition partition = partitioner.Partition(_sharesList);

            // Assert
            Assert.AreEqual(4, partition.Size);
        }

        [Test]
        public void Partitioning_a_list_of_four_items_by_four_produces_a_partition_of_size_one()
        {
            // Arrange
            Partitioner partitioner = new Partitioner(4);

            // Act
            Partition partition = partitioner.Partition(_sharesList);

            // Assert
            Assert.AreEqual(1, partition.Size);
        }

        [Test]
        public void Partitioning_a_list_of_four_items_by_two_produces_a_partition_of_size_two()
        {
            // Arrange
            Partitioner partitioner = new Partitioner(2);

            // Act
            Partition partition = partitioner.Partition(_sharesList);

            // Assert
            Assert.AreEqual(2, partition.Size);
        }

        #region HELPERS
        private List<Share> CreateSharesListOfSize(int size)
        {
            List<Share> shares = new List<Share>();
            for (int i = 0; i < size; i++)
            {
                shares.Add(new Share() { Maximum = 130, Minimum = 15 });
            }
            return shares;
        }
        #endregion
    }
}

